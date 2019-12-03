using System;
using System.Linq;
using DesignPatterns.Events;
using DesignPatterns.Infrastructure;

namespace DesignPatterns.Commands
{
    public class TableAggregateRoot : AggregateRoot<TableEntity>
    {
        public TableAggregateRoot(TableEntity entity) : base(entity)
        {
        }

        public TableAggregateRoot(Guid id, string name):base()
        {
            Entity = new TableEntity(id, name);
            Publish(new TableWasOpenedEvent(Entity.Id, Entity.Name), "openTable");
            Console.WriteLine($"{name} Table have been Opened with ID : {id} ");
        }

        public void CloseTable()
        {
            Publish(new TableWasClosedEvent(Entity.Id), "closeTable");
            Console.WriteLine($"{Entity.Name} Table have been closed.");
        }

        public void AddOrder(int number, string foods)
        {
            CheckForDuplicateOrderNumbers(number);
            var newOrder = new Order
            {
                Number = number,
                Foods = foods
            };
            Entity.Orders.Add(newOrder);
            Publish(new OrderAddedEvent(Entity.Id, newOrder.Number, newOrder.Foods), "newOrder");
            Console.WriteLine("Order Completed.");
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