using System;
using DesignPatterns.Infrastructure.Events;

namespace DesignPatterns.Events
{
    public class TableWasClosedEvent : IEvent
    {
        public int Id { get; }
        public TableWasClosedEvent(int id)
        {
            Id = id;
        }
    }
}
