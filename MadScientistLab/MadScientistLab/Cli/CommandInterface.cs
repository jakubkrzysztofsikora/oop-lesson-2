using System;

namespace MadScientistLab.Cli
{
    public class CommandInterface : ICommandInterface
    {
        public void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void DisplayInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void DisplayBark(string name)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{name}: Bark bark!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void DisplayPurr(string name)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{name}: Purrrrr!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void DisplaySqueak(string name)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{name}: Squeeeeeaaaak!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
