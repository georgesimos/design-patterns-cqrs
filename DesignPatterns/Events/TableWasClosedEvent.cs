using System;
using DesignPatterns.Infrastructure.Events;

namespace DesignPatterns.Events
{
    public class TableWasClosedEvent : IEvent
    {
        public int Id;
        public TableWasClosedEvent(int id)
        {
            Id = id;
        }
    }
}
