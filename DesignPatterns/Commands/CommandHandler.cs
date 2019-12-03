using System;
using DesignPatterns.Commands;
using DesignPatterns.Infrastructure;


namespace DesignPatterns.Handlers
{
    public class CommandHandler : ICommandHandler<OpenTableCommand>
        , ICommandHandler<CloseTableCommand>
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
        }

        public void Handle(NewOrderCommand command)
        {
            var entity = _entityStorage.GetById<TableEntity>(command.Id);
            var aggregate = new TableAggregateRoot(entity);

            aggregate.AddOrder(command.Foods);
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
