using System;
using DesignPatterns.Infrastructure.Events;

namespace DesignPatterns.Events
{
    public class TableWasClosedEvent : IEvent
    {
        public Guid Id { get; }
        public TableWasClosedEvent(Guid id)
        {
            Id = id;
        }
    }
}
