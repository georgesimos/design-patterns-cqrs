using System;
using DesignPatterns.Infrastructure.Events;

namespace DesignPatterns.Events
{
    public class TableWasOpenedEvent: IEvent
    {
        public int Id;
        public TableWasOpenedEvent(int id)
        {
            Id = id;
        }
    }
}
