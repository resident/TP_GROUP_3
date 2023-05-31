using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal static class Alert
    {
        private static void Message(string message, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            var oldForegroundColor = Console.ForegroundColor;
            var oldBackgroundColor = Console.BackgroundColor;

            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;

            Console.WriteLine(message);

            Console.ForegroundColor = oldForegroundColor;
            Console.BackgroundColor = oldBackgroundColor;
        }

        public static void Show(string message)
        {
            Message(message);
        }

        public static void Successful(string message)
        {
            Message(message, ConsoleColor.Green);
        }

        public static void Warning(string message)
        {
            Message(message, ConsoleColor.Yellow);
        }

        public static void Error(string message)
        {
            Message(message, ConsoleColor.Red);
        }
    }
}
