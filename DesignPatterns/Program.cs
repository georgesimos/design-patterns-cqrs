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

        // EventStore: create an SQLite file called events for saving the events
        // For simplicity we dont store our events with extra meta data like version and timestamp
        // We could use those meta data for reproduce the data from our event store
        private static readonly EventStore _eventStore = new EventStore();
        // Creating the app database
        private static readonly AppDatabase _database = new AppDatabase();
        // Will register in a queue the commands and in a topic the events
        // And Using the EntityStorage it will Execute the event
        private static readonly Bus bus = new Bus();
        // Using the bus for sending the events... 
        private static readonly EntityStorage _tablesDb = new EntityStorage(bus);
        // Commands Handler
        private static readonly CommandHandler _commandHandler = new CommandHandler(_tablesDb, bus);
        // Queries Handler
        private static readonly QueryHandler _queryHandler = new QueryHandler(_database);
        // Queries Event Handler similar with the Queries Handler
        // Exist only for showing the events to the user.
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

                        // Retry pattern 
                        var tables = RetryUtils.RetryIfThrown<ArgumentNullException, string>(() =>
                        {
                            return _queryHandler.Handle(new Queries.GetAllTablesQuery());

                        }, 2, 300);

                        Console.WriteLine("All Tables: " + tables);

                        break;
                    case 5: // View all Orders

                        Console.WriteLine(_queryHandler.Handle(new Queries.GetAllOrdersQuery()));

                        // Retry pattern 
                        var data = RetryUtils.RetryIfThrown<ArgumentNullException, string>(() =>
                        {
                            return _queryHandler.Handle(new Queries.GetAllOrdersQuery());

                        }, 3, 250);

                        Console.WriteLine("Fetched data: " + data);

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
