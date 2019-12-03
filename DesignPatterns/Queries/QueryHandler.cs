//using System;
//using System.Linq;
//using System.Text.Json;
//using DesignPatterns.Infrastructure;
//using DesignPatterns.Queries;

//namespace DesignPatterns.Handlers
//{
//    public class QueryHandler : IQueryHandler<GetAllTablesQuery>, IQueryHandler<FindTableQuery>
//    {
//        private TablesDb _db;

//        public QueryHandler(TablesDb db)
//        {
//            _db = db;
//        }

//        public string Handle(GetAllTablesQuery query)
//        {
//            return JsonSerializer.Serialize(_db.Tables);
//        }
//        public string Handle(FindTableQuery query)
//        {
//            var table = _db.Tables.FirstOrDefault(table => table.Id == query.Id);

//            return JsonSerializer.Serialize(table);
//        }


//    }
//}
