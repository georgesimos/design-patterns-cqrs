using System;
using RestaurantDesignPatterns.Commands;
using RestaurantDesignPatterns.Handlers;
using RestaurantDesignPatterns.Infrastructure;

namespace RestaurantDesignPatterns
{
    class Program
    {

        private static readonly DataBase _db = new DataBase();
        private static readonly CommandHandler _commandHandler = new CommandHandler(_db);
    
        static void Main(string[] args)

        {
            string keypress;
            do
            {
                Console.WriteLine("Restaurant Design Patterns");
                Console.WriteLine();

                Console.WriteLine("Select Command:");

                Console.WriteLine();
                Console.WriteLine("1) Open Table");
                Console.WriteLine("2) Close Table");

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
                            _commandHandler.Handle(command);

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
                            _commandHandler.Handle(command);

                            Console.WriteLine();
                            Console.WriteLine("Table closed");
                        }
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
