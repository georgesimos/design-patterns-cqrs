using System;
using System.Collections.Generic;
using DesignPatterns.Models;

namespace DesignPatterns.Infrastructure
{
    public class TablesDb
    {
        // In memory Db
        public IList<Table> Tables = new List<Table>();
    
    }
}
