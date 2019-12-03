using System;
using DesignPatterns.Infrastructure.Events;

namespace DesignPatterns.Events
{
    public class OrderAddedEvent : IEvent
    {
        public Guid Id { get; }
        public int Number { get; set; }
        public string Foods { get; set; }

        public OrderAddedEvent(Guid id, int number, string foods)
        {
            Id = id;
            Number = number;
            Foods = foods;

        }
    }
}
