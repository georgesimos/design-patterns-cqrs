using System;
namespace DesignPatterns.Commands
{
    public class CloseTableCommand: ICommand
    {
        public Guid Id { get; set; }

        public CloseTableCommand(Guid id)
        {
            Id = id;
        }
    }
}
