//using Raven.Client;
//using Raven.Client.Document;
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
        /*
        private static ConcurrentDictionary<String, object> database = new ConcurrentDictionary<string, object>();

        public static bool Store(string key, object data)
        {



            if (!database.TryAdd(key, data))
            {
                return database.TryUpdate(key, data, database[key]);

            }
            return true;
        }
        public static object Recall(string key, object data)
        {
            database.TryGetValue(key, out data);
            return data;
        }

        public static string RavenDBSavePage(CI.Page ob)
        {

            using (IDocumentStore store = new DocumentStore
            {
                Url = "http://localhost:1234/", // server URL
                DefaultDatabase = "Void"   // default database
            })
            {
                store.Initialize(); // initializes document store, by connecting to server and downloading various configurations

                using (IDocumentSession session = store.OpenSession()) // opens a session that will work in context of 'DefaultDatabase'
                {
                 
                    session.Store(ob); // stores employee in session, assigning it to a collection `Employees`
                   // Session.Store will assign Id to employee, if it is not set

                    session.SaveChanges(); // sends all changes to server
                return  ob.Id;
                }
            }
        }
        public static CI.Page RavenDBLoadPage(int idb) { return RavenDBLoadPage(idb.ToString()); }


        public static CI.Page RavenDBLoadPage(string idb)
        {

            using (IDocumentStore store = new DocumentStore
            {
                Url = "http://localhost:1234/", // server URL
                DefaultDatabase = "Void"   // default database
            })
            {
                store.Initialize(); // initializes document store, by connecting to server and downloading various configurations

                using (IDocumentSession session = store.OpenSession()) // opens a session that will work in context of 'DefaultDatabase'
                {

                   var x =   session.Load<CI.Page>(idb);
                    if (x != null)
                    {
                        return x;
                    }


                    return new CI.Page() { Note = 36, Id = (idb).ToString() };
                    
                }
            }
        }

    */
    }
}
