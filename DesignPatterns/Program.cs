using System;
using DesignPatterns.Commands;
using DesignPatterns.Handlers;
using DesignPatterns.Infrastructure;
using DesignPatterns.Queries;
using DesignPatterns.Infrastructure.DbContexts;


namespace DesignPatterns
{
    class Program
    {


        private static readonly EventStore _eventStore = new EventStore();
        private static readonly AppDatabase _database= new AppDatabase();

        private static readonly Bus bus = new Bus();

        private static readonly EntityStorage _tablesDb = new EntityStorage(bus);
        private static readonly CommandHandler _commandHandler = new CommandHandler(_tablesDb, bus);
        private static readonly QueryHandler _queryHandler = new QueryHandler(_database);
        private static readonly QueryEventsHandler _eventStoreHandler = new QueryEventsHandler(_eventStore);

        static void Main(string[] args)
        {

            string keypress;
            do
            {
                Console.WriteLine("Design Patterns -- Restaurant Example");
                Console.WriteLine();

                Console.WriteLine("Select Command:");

                Console.WriteLine();
                Console.WriteLine("1) Open Table");
                Console.WriteLine("2) Add Order");
                Console.WriteLine("3) Close Table");
                Console.WriteLine("4) View Open Tables");
                Console.WriteLine("5) View All Orders");
                Console.WriteLine("6) Find Open Table");
                Console.WriteLine("7) Show All Events");

                var selection = Console.ReadKey().KeyChar.ToString();
                int.TryParse(selection, out int actionSelection);
                Console.Clear();


                switch (actionSelection)
                {
                    case 1: // Open Table
                        {
                            var id = Guid.NewGuid();

                            Console.WriteLine();
                            Console.Write("Table Name: ");
                            var name = Console.ReadLine();

                            var command = new OpenTableCommand(id, name);

                            _commandHandler.Handle(command);

                            Console.WriteLine();
                        }
                        break;
                    case 2: // Add Order
                        {
                            Console.Write("Select Table ID: ");
                            var id = Console.ReadLine();
                            Guid.TryParse(id, out Guid tableId);

                            Console.WriteLine();
                            Console.Write("Foods Order: ");
                            var foods = Console.ReadLine();
             

                            var command = new NewOrderCommand(tableId, foods);
                            _commandHandler.Handle(command);

                            Console.WriteLine();
                        }
                        break;

                    case 3: // Close Table
                        {
                            Console.Write("Table ID: ");
                            var id = Console.ReadLine();
                            Guid.TryParse(id, out Guid tableId);

                            var command = new CloseTableCommand(tableId);
                            _commandHandler.Handle(command);

                            Console.WriteLine();
                            Console.WriteLine("Table closed");
                        }
                        break;
                    case 4: // View all Open Tables
                        Console.WriteLine(_queryHandler.Handle(new Queries.GetAllTablesQuery()));

                        break;
                    case 5: // View all Orders
            
                        Console.WriteLine(_queryHandler.Handle(new Queries.GetAllOrdersQuery()));

                        break;

                    case 6: // Find Open Table
                        {
                            Console.Write("Table Name: ");
                            var name = Console.ReadLine();

                            var query = new FindTableQuery(name);

                            Console.WriteLine();
                            Console.WriteLine(_queryHandler.Handle(query));
                        }
                        break;
                    case 7: // Show All Events
                        Console.WriteLine(_eventStoreHandler.Handle(new ShowEvents()));
                        break;

                    default:// Invalid choice - skip and display start menu
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Menu ( M )");
                Console.WriteLine("Exit ( X )");

                keypress = Console.ReadKey().KeyChar.ToString();
            } while (keypress.ToLower() != "x");

        }
    }
}
