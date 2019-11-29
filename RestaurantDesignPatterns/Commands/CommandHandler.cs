using System;
using System.Linq;
using RestaurantDesignPatterns.Commands;
using RestaurantDesignPatterns.Infrastructure;
using RestaurantDesignPatterns.Models;

namespace RestaurantDesignPatterns.Handlers
{
    public class CommandHandler : ICommandHandler<OpenTableCommand>,ICommandHandler<CloseTableCommand>
    {
        private DbContext _dbContext;

        public CommandHandler(DbContext db)
        {
            _dbContext = db;
        }

        public void Handle(OpenTableCommand command)
        {
            _dbContext.Tables.Add(new Table { Id = command.Id,  Name = command.Name });
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
