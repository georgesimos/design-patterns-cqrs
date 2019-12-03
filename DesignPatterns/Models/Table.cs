using System;
namespace DesignPatterns.Models
{
    public class Table
    {
        public Table(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Version { get; set; }
    }
}
