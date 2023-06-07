using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Client
{
    internal static class Alert
    {
        public static void Show(string message, bool log = true)
        {
            MessageBox.Show(message);

            if (log) Log.Write(message, Log.TypeNotice);
        }

        public static void Successful(string message, bool log = true)
        {
            MessageBox.Show(message, @"Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (log) Log.Write(message, Log.TypeNotice);
        }

        public static void Warning(string message, bool log = true)
        {
            MessageBox.Show(message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (log) Log.Write(message, Log.TypeWarning);
        }

        public static void Error(string message, bool log = true)
        {
            MessageBox.Show(message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (log) Log.Write(message, Log.TypeError);
        }
    }
}
