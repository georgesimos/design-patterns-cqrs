using System;
using System.Collections.Generic;
using RestaurantDesignPatterns.Models;

namespace RestaurantDesignPatterns.Infrastructure
{
    public class DbContext
    {
        // In memory Db
        public IList<Table> Tables = new List<Table>();
    
    }
}
