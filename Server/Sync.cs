using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public static class Sync
    {
        public static DateTime GetLastChangeTime()
        {
            return Storage.Get<DateTime>("lastChangeTime");
        }

        public static void UpdateLastChangeTime()
        {
            Storage.Set("lastChangeTime", DateTime.Now);
        }
    }
}
