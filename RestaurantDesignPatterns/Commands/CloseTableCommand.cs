using System;
namespace RestaurantDesignPatterns.Commands
{
    public class CloseTableCommand: ICommand
    {
        public int Id { get; private set; }

        public CloseTableCommand(int id)
        {
            Id = id;
        }
    }
}
