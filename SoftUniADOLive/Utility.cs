using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniADOLive
{
    public class Utility
    {
        public static void PrintHLine()
        {
            Console.Write(new string('-', Console.WindowWidth));
        }

        public static void Paginate() { }

        public static int MenuNavigationLogic(List<string> menuOptions)
        {
            int pointer = 1;
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();
                Console.WriteLine("Please select a module: ");
                int current = 1;
                foreach (var menuOption in menuOptions)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    if (current == pointer)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(menuOption);
                    current++;
                }

                var key = Console.ReadKey();

                switch (key.Key.ToString())
                {
                    case "Enter":
                        return pointer;
                    case "UpArrow":
                        if (pointer == 1)
                        {
                            break;
                        }
                        pointer--;
                        break;
                    case "DownArrow":
                        if (pointer == menuOptions.Count())
                        {
                            break;
                        }
                        pointer++;
                        break;

                }
            }
        }
    }
}
