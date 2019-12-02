using System;
using DesignPatterns.Infrastructure;
using DesignPatterns.Infrastructure.DbContexts;
using DesignPatterns.Infrastructure.Events;
using DesignPatterns.Models;

namespace DesignPatterns.Events
{
    public class EventHandler : IEventHandler<TableWasOpenedEvent>, IEventHandler<TableWasClosedEvent>
    {
        private EventStore _eventStore;

        public EventHandler(EventStore store)
        {
            _eventStore = store;
        }

        public void Handle(TableWasOpenedEvent @event)
        {
            System.Console.WriteLine($"EVENT : Table Was Opened ID: {@event.Id}");
            var newEvent = new Event(@event.Id, "Table Was Opened");
            _eventStore.Events.Add(newEvent);
            _eventStore.SaveChanges();
            
               
        }

        public void Handle(TableWasClosedEvent @event)
        {
            System.Console.WriteLine($"EVENT : Table Was Closed ID: {@event.Id}");
            var newEvent = new Event(@event.Id, "Table Was Closed");
            _eventStore.Add(newEvent);
            _eventStore.SaveChanges();
        }
    }
}
