using System;
namespace DesignPatterns.Commands
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
