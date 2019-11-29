using System;
namespace RestaurantDesignPatterns.Queries
{
    public class FindTableQuery : IQuery
    {
        public int Id { get; private set; }
        public FindTableQuery(int id)
        {
            Id = id;
        }
    }
}
