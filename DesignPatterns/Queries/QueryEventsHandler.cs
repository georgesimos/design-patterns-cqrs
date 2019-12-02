using System;
using System.Text.Json;
using DesignPatterns.Infrastructure.DbContexts;

namespace DesignPatterns.Queries
{
    public class QueryEventsHandler
    {
        private EventStore _store;

        public QueryEventsHandler(EventStore store)
        {
            _store = store;
        }

        public string Handle(ShowEvents query)
        {
            return JsonSerializer.Serialize(_store.Events);
        }
    }
}
