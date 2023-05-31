using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal static class Alert
    {
        public static void Show(string message)
        {
            MessageBox.Show(message);
        }

        public static void Successful(string message)
        {
            MessageBox.Show(message, "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Warning(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Error(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
