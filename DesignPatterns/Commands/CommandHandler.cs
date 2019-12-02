using System;
using System.Linq;
using DesignPatterns.Commands;
using DesignPatterns.Events;
using DesignPatterns.Infrastructure;
using DesignPatterns.Infrastructure.Events;
using DesignPatterns.Models;

namespace DesignPatterns.Handlers
{
    public class CommandHandler : ICommandHandler<OpenTableCommand>,ICommandHandler<CloseTableCommand>
    {
        private TablesDb _dbContext;
        private readonly IEventsBus _eventPublisher;

        public CommandHandler(TablesDb db, IEventsBus eventPublisher)
        {
            _dbContext = db;
            _eventPublisher = eventPublisher;
        }

        public void Handle(OpenTableCommand command)
        {
            _dbContext.Tables.Add(new Table(command.Id,  command.Name));
            //_eventPublisher.Publish(new TableWasOpenedEvent(command.Id));
        }

        public void Handle(CloseTableCommand command)
        {
            var table = _dbContext.Tables.FirstOrDefault(t => t.Id == command.Id);

            if (table != null)
            {
                _dbContext.Tables.Remove(table);
            }
        }

    }
}
