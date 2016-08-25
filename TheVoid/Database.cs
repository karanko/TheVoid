using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVoid
{
   public class Database
    {

        private static ConcurrentDictionary<String, object> database = new ConcurrentDictionary<string, object>();

        public static bool Store(string key, object data)
        {
            return database.TryAdd(key, data);
        }
        public static object Recall(string key, object data)
        {
            database.TryGetValue(key, out data);
            return data;
        }
    }
}
