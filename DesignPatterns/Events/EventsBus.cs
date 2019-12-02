using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using DesignPatterns.Infrastructure.Events;

namespace DesignPatterns.Events
{
    public class EventsBus : IEventsBus
    {
        public void Publish<T>(T @event) where T : IEvent
        {
            var handlers = IoC.Container.Resolve<IEnumerable<IEventHandler<T>>>().ToList();

            handlers.ForEach(h => h.Handle(@event));
            //Parallel.ForEach(handlers, h => h.Handle(@event));
        }
    }
}
