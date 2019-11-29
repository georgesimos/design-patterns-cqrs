using System;
using System.Linq;
using RestaurantDesignPatterns.Commands;
using RestaurantDesignPatterns.Infrastructure;
using RestaurantDesignPatterns.Models;

namespace RestaurantDesignPatterns.Handlers
{
    public class CommandHandler : ICommandHandler
    {
        private DataBase _db;

        public CommandHandler(DataBase db)
        {
            _db = db;
        }

        public void Handle(OpenTableCommand command)
        {
            _db.Tables.Add(new Table { Id = command.Id,  Name = command.Name });
        }

        public void Handle(CloseTableCommand command)
        {
            var table = _db.Tables.FirstOrDefault(c => c.Id == command.Id);

            if (table != null)
            {
                _db.Tables.Remove(table);
            }
        }

    }
}
