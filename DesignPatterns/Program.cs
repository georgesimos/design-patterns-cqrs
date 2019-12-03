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
        private static readonly Bus bus = new Bus();
        private static readonly EntityStorage _tablesDb = new EntityStorage(bus);
        private static readonly CommandHandler _commandHandler = new CommandHandler(_tablesDb, bus);
        //private static readonly QueryHandler _queryHandler = new QueryHandler(_tablesDb);
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
                Console.WriteLine("5) Find Open Table");
                Console.WriteLine("6) Show Events");

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
                    case 2: // Close Table
                        {
                            Console.Write("Select Table ID: ");
                            var id = Console.ReadLine();
                            Guid.TryParse(id, out Guid tableId);

                            Console.WriteLine();
                            Console.Write("Order Number ID : ");
                            var num = Console.ReadKey().KeyChar.ToString();
                            int.TryParse(num, out int number);

                            Console.WriteLine();
                            Console.Write("Foods Order: ");
                            var foods = Console.ReadLine();
             

                            var command = new NewOrderCommand(tableId, number, foods);
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
                        //Console.WriteLine(_queryHandler.Handle(new Queries.GetAllTablesQuery()));
                        break;

                    case 5: // Find Open Table
                        {
                            Console.Write("Table ID: ");
                            var id = Console.ReadKey().KeyChar.ToString();
                            int.TryParse(id, out int tableId);

                            var query = new FindTableQuery(tableId);

                            Console.WriteLine();
                            //Console.WriteLine(_queryHandler.Handle(query));
                        }
                        break;
                    case 6: // Show All Events
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
