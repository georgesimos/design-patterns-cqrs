using System;
using System.Collections.Generic;

namespace DesignPatterns.Infrastructure
{
    public class EntityStorage
    {
        private readonly Dictionary<Guid, object> _storage = new Dictionary<Guid, object>();
        private readonly Bus _bus;

        public EntityStorage(Bus bus)
        {
            _bus = bus;
        }

        public void Save<T>(Guid id, AggregateRoot<T> aggregate)
        {
            _storage[id] = aggregate.Entity;
            foreach (var @event in aggregate.GetUnsentEvents())
            {
                _bus.Send(@event);
            }

        }

        public T GetById<T>(Guid id)
        {
            Console.WriteLine((T)_storage[id]);
            return (T)_storage[id];
        }
    }
}
