using System;
namespace DesignPatterns.Commands
{
    public class NewOrderCommand : ICommand
    {
        public Guid Id { get; }
        public int Number { get; set; }
        public int Quantity { get; set; }
        public string Foods { get; set; }

        public NewOrderCommand(Guid id, int number, string foods)
        {
            Id = id;
            Number = number;
            Foods = foods;
        }
    }
}
