using System;
namespace DesignPatterns.Commands
{
    public class CloseTableCommand: ICommand
    {
        public int Id;

        public CloseTableCommand(int id)
        {
            Id = id;
        }
    }
}
