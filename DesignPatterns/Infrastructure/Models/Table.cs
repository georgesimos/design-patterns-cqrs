using System;
namespace DesignPatterns.Models
{
    public class Table
    {
        public Table(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

    }
}
