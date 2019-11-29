using System;
using System.Collections.Generic;
using RestaurantDesignPatterns.Models;

namespace RestaurantDesignPatterns.Infrastructure
{
    public class DataBase
    {
        // In memory Db
        public IList<Table> Tables = new List<Table>();
    
    }
}
