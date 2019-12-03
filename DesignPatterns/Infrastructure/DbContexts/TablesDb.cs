using System;
using System.Collections.Generic;
using DesignPatterns.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Infrastructure
{
    public class AppDatabase : DbContext
    {
        private static bool _created = false;

        public AppDatabase()
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
            optionsBuilder.UseSqlite("Filename=./app.db");
        }

        // In memory Db
        //public IList<Event> Events = new List<Event>();
        public DbSet<Table> Tables { get; set; }
    }



}
