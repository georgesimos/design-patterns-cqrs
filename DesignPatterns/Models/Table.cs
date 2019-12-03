using System;
using System.Collections.Generic;

namespace DesignPatterns.Models
{
    public class Table
    {
		public Guid TableId { get; set; }
		public string Name { get; set; }

        public List<Order> Orders { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public string Foods { get; set; }

        public Table Table { get; set; }
    }
}
