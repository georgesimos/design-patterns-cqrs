using System;
namespace RestaurantDesignPatterns.Commands
{
    public class OpenTableCommand: ICommand
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public OpenTableCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
