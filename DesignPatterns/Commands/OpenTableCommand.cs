using System;
namespace DesignPatterns.Commands
{
    public class OpenTableCommand: ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public OpenTableCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
