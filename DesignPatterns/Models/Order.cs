using System;
namespace DesignPatterns.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Guid TableId { get; set; }
        public string Foods { get; set; }
    }
}
