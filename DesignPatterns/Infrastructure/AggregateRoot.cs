using System;
using System.Collections.Generic;
using DesignPatterns.Infrastructure.DbContexts;
using DesignPatterns.Models;

namespace DesignPatterns.Infrastructure
{
    public class AggregateRoot<T>
    {
        private EventStore _eventStore = new EventStore();

        protected AggregateRoot()
        {

        }
        public AggregateRoot(T entity)
        {
            Entity = entity;
        }

        private readonly List<object> _unsentEvents = new List<object>();

        public IEnumerable<object> GetUnsentEvents()
        {
            return _unsentEvents;
        }

        public void ClearEvents()
        {
            _unsentEvents.Clear();
        }

        public T Entity { get; protected set; }

        protected void Publish(object @event, string description)
        {
            _unsentEvents.Add(@event);
            var id = Guid.NewGuid();
            var newEvent = new Event(id, description);
            _eventStore.Events.Add(newEvent);
            _eventStore.SaveChanges();
        }
    }
}
