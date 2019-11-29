using System;
using System.Linq;
using System.Text.Json;
using DesignPatterns.Infrastructure;
using DesignPatterns.Queries;

namespace DesignPatterns.Handlers
{
    public class QueryHandler : IQueryHandler<GetAllTablesQuery>, IQueryHandler<FindTableQuery>
    {
        private DbContext _dbContext;

        public QueryHandler(DbContext db)
        {
            _dbContext = db;
        }

        public string Handle(GetAllTablesQuery query)
        {
            return JsonSerializer.Serialize(_dbContext.Tables);
        }
        public string Handle(FindTableQuery query)
        {
            var table = _dbContext.Tables.FirstOrDefault(table => table.Id == query.Id);

            return JsonSerializer.Serialize(table);
        }


    }
}
