using System;
using DesignPatterns.Infrastructure;
using DesignPatterns.Infrastructure.DbContexts;
using DesignPatterns.Infrastructure.Events;
using DesignPatterns.Models;

namespace DesignPatterns.Events
{
    public class EventHandler : IEventHandler<TableWasOpenedEvent>
       //, IEventHandler<TableWasClosedEvent>
    {
        private EventStore _eventStore;
        private Bus _bus;

        public EventHandler(EventStore store, Bus bus)
        {
            _eventStore = store;
            _bus = bus;
            _bus.RegisterTopic<TableWasOpenedEvent>(Handle);
            _bus.RegisterTopic<TableWasClosedEvent>(Handle);
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
            _eventStore.Events.Add(newEvent);
            _eventStore.SaveChanges();
        }
    }
}
