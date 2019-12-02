using System;
namespace DesignPatterns.Commands
{
    public class OpenTableCommand: ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public OpenTableCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
