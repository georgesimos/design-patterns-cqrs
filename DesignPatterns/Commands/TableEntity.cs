using System;
using System.Collections.Generic;

namespace DesignPatterns.Commands
{
    public class TableEntity

    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<OrderEntity> Orders { get; set; }

        public TableEntity()
        {
            Orders = new List<OrderEntity>();
        }

        public TableEntity(Guid id, string name)
        {
            Id = id;
            Name = name;
            Orders = new List<OrderEntity>();
        }
    }

    public class OrderEntity
    {
        public string Foods { get; set; }
    }
}
