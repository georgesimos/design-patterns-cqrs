using System;
namespace DesignPatterns.Infrastructure.Events
{
    public interface IEventHandler
    {
    }
    public interface IEventHandler<T> : IEventHandler
    where T : IEvent
    {
        void Handle(T @event);
    }
}
