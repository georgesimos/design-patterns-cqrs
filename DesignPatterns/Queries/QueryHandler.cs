using System;
using System.Linq;
using System.Text.Json;
using DesignPatterns.Infrastructure;
using DesignPatterns.Queries;

namespace DesignPatterns.Handlers
{
    public class QueryHandler : IQueryHandler<GetAllTablesQuery>, IQueryHandler<GetAllOrdersQuery>
    //, IQueryHandler<FindTableQuery>
    {
        private AppDatabase _db;

        public QueryHandler(AppDatabase db)
        {
            _db = db;
        }

        public string Handle(GetAllTablesQuery query)
        {
            return JsonSerializer.Serialize(_db.Tables);
        }

        public string Handle(GetAllOrdersQuery query)
        {
            return JsonSerializer.Serialize(_db.Orders);
        }

        public string Handle(FindTableQuery query)
        {
            var table = _db.Tables.Single(table => table.Name == query.Name);
            return JsonSerializer.Serialize(table);
        }
    }
}
