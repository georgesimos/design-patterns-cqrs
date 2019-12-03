using System;
namespace DesignPatterns.Infrastructure.Events
{
    public interface IEventsBus
    {
        void Publish<T>(T @event) where T : IEvent;
    }
}
