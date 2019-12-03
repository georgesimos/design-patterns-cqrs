using System;
namespace DesignPatterns.Queries
{
    public class FindTableQuery : IQuery
    {
        public string Name;
        public FindTableQuery(string name)
        {
            Name = name;
        }
    }
}
