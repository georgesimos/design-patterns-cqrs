using System;
using System.Linq;
using System.Text.Json;
using DesignPatterns.Commands;
using DesignPatterns.Events;
using DesignPatterns.Infrastructure;
using DesignPatterns.Infrastructure.Events;
using DesignPatterns.Models;

namespace DesignPatterns.Handlers
{
    public class CommandHandler : ICommandHandler<OpenTableCommand>
        //, ICommandHandler<CloseTableCommand>
    {
        private EntityStorage _entityStorage;
        private readonly Bus _bus;

        public CommandHandler(EntityStorage entityStorage, Bus bus)
        {
            _entityStorage = entityStorage;
            _bus = bus;
            _bus = bus;
            _bus.RegisterQueue<OpenTableCommand>(Handle);
            _bus.RegisterQueue<CloseTableCommand>(Handle);
        }

        public void Handle(OpenTableCommand command)
        {
            var aggregate = new TableAggregateRoot(command.Id, command.Name);
    
            _entityStorage.Save(command.Id, aggregate);

            //_eventPublisher.Publish(new TableWasOpenedEvent(command.Id));
            //var entity = _dbContext;
            //Console.WriteLine(JsonSerializer.Serialize(entity));
        }

        public void Handle(NewOrderCommand command)
        {
            var entity = _entityStorage.GetById<TableEntity>(command.Id);
            var aggregate = new TableAggregateRoot(entity);

            aggregate.AddOrder(command.Number, command.Foods);
            _entityStorage.Save(command.Id, aggregate);
        }


        public void Handle(CloseTableCommand command)
        {
            var entity = _entityStorage.GetById<TableEntity>(command.Id);
            var aggregate = new TableAggregateRoot(entity);
            aggregate.CloseTable();
            _entityStorage.Save(command.Id, aggregate);
        }

    }
}
