using System;
namespace DesignPatterns.Commands
{
    public class CloseTableCommand: ICommand
    {
        public int Id { get; set; }

        public CloseTableCommand(int id)
        {
            Id = id;
        }
    }
}
