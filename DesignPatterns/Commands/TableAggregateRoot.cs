using System;
using System.Collections.Generic;
using System.Linq;
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

        public void AddOrder(int number, string foods)
        {
            CheckForDuplicateOrderNumbers(number);
            var newOrder = new OrderEntity
            {
                Number = number,
                Foods = foods
            };
            Entity.Orders.Add(newOrder);
            Publish(new OrderAddedEvent(Entity.Id, newOrder.Number, newOrder.Foods), "newOrder");
            Console.WriteLine("Order Completed.");
            //var tab = new Table
            //    {
            //        Name = "salam",
            //        Orders = new List<Order>
            //    {
            //        new Order { Foods = "Omelet"},
            //        new Order { Foods = "Patote" },
            //        new Order { Foods = "Mousakas" }
            //    }
            //            };
            //        _database.Tables.Add(tab);
            //        _database.SaveChanges();
                }

        private void CheckForDuplicateOrderNumbers(int number)
        {
            if (Entity.Orders.Any(order => order.Number == number))
            {
                throw new Exception("Duplicate order number");
            }
        }
    }


}