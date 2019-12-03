using System;
using System.Collections.Generic;

namespace DesignPatterns.Commands
{
    public class TableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }

        public TableEntity()
        {
            Orders = new List<Order>();
        }

        public TableEntity(Guid id, string name)
        {
            Id = id;
            Name = name;
            Orders = new List<Order>();
        }
    }

    public class Order
    {
        public int Number { get; set; }
        public string Foods { get; set; }
    }
}
