using System;
using DesignPatterns.Events;
using DesignPatterns.Commands;
using DesignPatterns.Handlers;
using DesignPatterns.Infrastructure;
using DesignPatterns.Queries;

using EventHandler = DesignPatterns.Events.EventHandler;
using DesignPatterns.Infrastructure.DbContexts;

namespace DesignPatterns
{
    class Program
    {
        
        private static readonly TablesDb _tablesDb = new TablesDb();
        private static readonly EventStore _eventStore = new EventStore();
        private static readonly EventsBus _eventPublisher = new EventsBus();
        private static readonly EventHandler _eventHandler = new EventHandler(_eventStore);
        private static readonly CommandHandler _commandHandler = new CommandHandler(_tablesDb, _eventPublisher);
        private static readonly QueryHandler _queryHandler = new QueryHandler(_tablesDb);
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
                Console.WriteLine("2) Close Table");
                Console.WriteLine("3) View Open Tables");
                Console.WriteLine("4) Find Open Table");
                Console.WriteLine("5) Show Events");

                var selection = Console.ReadKey().KeyChar.ToString();
                int.TryParse(selection, out int actionSelection);
                Console.Clear();


                switch (actionSelection)
                {
                    case 1: // Open Table
                        {
                            Console.Write("Table ID: ");
                            var id = Console.ReadKey().KeyChar.ToString();
                            int.TryParse(id, out int tableId);

                            Console.WriteLine();
                            Console.Write("Table Name: ");
                            var name = Console.ReadLine();

                            var command = new OpenTableCommand(tableId, name);
                            var @event = new TableWasOpenedEvent(tableId);

                            _commandHandler.Handle(command);
                            _eventHandler.Handle(@event);

                            Console.WriteLine();
                            Console.WriteLine("Table added");
                        }
                        break;

                    case 2: // Close Table
                        {
                            Console.Write("Table ID: ");
                            var id = Console.ReadKey().KeyChar.ToString();
                            int.TryParse(id, out int tableId);

                            var command = new CloseTableCommand(tableId);
                            var @event = new TableWasClosedEvent(tableId);

                            _commandHandler.Handle(command);
                            _eventHandler.Handle(@event);

                            Console.WriteLine();
                            Console.WriteLine("Table closed");
                        }
                        break;
                    case 3: // View all Open Tables
                        Console.WriteLine(_queryHandler.Handle(new Queries.GetAllTablesQuery()));
                        break;

                    case 4: // Find Open Table
                        {
                            Console.Write("Table ID: ");
                            var id = Console.ReadKey().KeyChar.ToString();
                            int.TryParse(id, out int tableId);

                            var query = new FindTableQuery(tableId);

                            Console.WriteLine();
                            Console.WriteLine(_queryHandler.Handle(query));
                        }
                        break;
                    case 5: // Show All Events
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
