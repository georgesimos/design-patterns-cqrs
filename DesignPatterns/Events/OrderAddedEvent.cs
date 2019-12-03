using System;
using DesignPatterns.Infrastructure.Events;

namespace DesignPatterns.Events
{
    public class OrderAddedEvent : IEvent
    {
        public Guid Id { get; }
        public string Foods { get; set; }

        public OrderAddedEvent(Guid id,  string foods)
        {
            Id = id;
            Foods = foods;

        }
    }
}
