using System;
namespace DesignPatterns.Queries
{
    public class FindTableQuery : IQuery
    {
        public int Id;
        public FindTableQuery(int id)
        {
            Id = id;
        }
    }
}
