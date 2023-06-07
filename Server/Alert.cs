using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

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

        public static void Show(string message, bool log = true)
        {
            Message(message);

            if (log) Log.Write(message);
        }

        public static void Successful(string message, bool log = true)
        {
            Message(message, ConsoleColor.Green);

            if (log) Log.Write(message, Log.TypeNotice);
        }

        public static void Warning(string message, bool log = true)
        {
            Message(message, ConsoleColor.Yellow);

            if (log) Log.Write(message, Log.TypeWarning);
        }

        public static void Error(string message, bool log = true)
        {
            Message(message, ConsoleColor.Red);

            if (log) Log.Write(message, Log.TypeError);
        }
    }
}
