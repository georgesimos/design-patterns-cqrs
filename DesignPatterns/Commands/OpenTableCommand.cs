using System;
namespace DesignPatterns.Commands
{
    public class OpenTableCommand: ICommand
    {
        public int Id;
        public string Name;

        public OpenTableCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
