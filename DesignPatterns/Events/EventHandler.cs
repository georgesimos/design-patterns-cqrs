using System;
using DesignPatterns.Infrastructure;
using DesignPatterns.Infrastructure.Events;

namespace DesignPatterns.Events
{
    public class EventHandler : IEventHandler<TableWasOpenedEvent>, IEventHandler<TableWasClosedEvent>
    {
        private DbContext _dbContext;

        public EventHandler(DbContext db)
        {
            _dbContext = db;
        }

        public void Handle(TableWasOpenedEvent @event)
        {
            System.Console.WriteLine($"EVENT : Table Was Opened ID: {@event.Id}");
        }

        public void Handle(TableWasClosedEvent @event)
        {
            System.Console.WriteLine($"EVENT : Table Was Closed ID: {@event.Id}");
        }
    }
}
