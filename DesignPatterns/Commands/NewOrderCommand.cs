using System;
namespace DesignPatterns.Commands
{
    public class NewOrderCommand : ICommand
    {
        public Guid Id { get; }
        public string Foods { get; set; }

        public NewOrderCommand(Guid id, string foods)
        {
            Id = id;
            Foods = foods;
        }
    }
}
