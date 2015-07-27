using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace TestServer
{
    class Program
    {
        static void Main(string[] args)
        {

            HttpListener listener = new HttpListener(); 
            listener.Prefixes.Add("http://localhost:8081/foo/"); 
            listener.Prefixes.Add("http://127.0.0.1:8081/foo/"); 
            listener.Start();


        }
    }
}
