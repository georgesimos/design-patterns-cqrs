using System;
using DesignPatterns.Events;
using DesignPatterns.Infrastructure;
using DesignPatterns.Models;

namespace DesignPatterns.Commands
{
    public class TableAggregateRoot : AggregateRoot<TableEntity>
    {
        private AppDatabase _database = new AppDatabase();

        public TableAggregateRoot(TableEntity  entity) : base(entity)
        {
        }

        public TableAggregateRoot(Guid id, string name):base()
        {
            Entity = new TableEntity(id, name);
            Publish(new TableWasOpenedEvent(Entity.Id, Entity.Name), "openTable");
            Console.WriteLine($"{name} Table have been Opened with ID : {id} ");

            _database.Tables.Add(new Table { TableId=id, Name=name });
            _database.SaveChanges();
        }

        public void CloseTable()
        {
            Publish(new TableWasClosedEvent(Entity.Id), "closeTable");
            Console.WriteLine($"{Entity.Name} Table have been closed.");
        }

        public void AddOrder( string foods)
        {
            var newOrder = new OrderEntity
            {
                Foods = foods
            };

            Entity.Orders.Add(newOrder);
            Publish(new OrderAddedEvent(Entity.Id, newOrder.Foods), "newOrder");
            Console.WriteLine("Order Completed.");

            var nOrder = new Order { Foods =foods, TableId = Entity.Id};
            _database.Orders.Add(nOrder);
            _database.SaveChanges();
        }

    }


}