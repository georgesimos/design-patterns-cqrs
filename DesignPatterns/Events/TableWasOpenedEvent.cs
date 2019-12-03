using System;
using DesignPatterns.Infrastructure.Events;

namespace DesignPatterns.Events
{
    public class TableWasOpenedEvent: IEvent
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public TableWasOpenedEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
