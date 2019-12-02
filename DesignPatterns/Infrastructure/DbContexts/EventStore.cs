using System;
using System.Collections.Generic;
using System.IO;
using DesignPatterns.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Infrastructure.DbContexts
{
    public class EventStore : DbContext
    {
        private static bool _created = false;

        public EventStore()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./events.db");
        }

        // In memory Db
        //public IList<Event> Events = new List<Event>();
        public DbSet<Event> Events { get; set; }
    }

 
}
