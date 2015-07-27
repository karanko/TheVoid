
using System;
using System.Linq;

namespace WCFTest
{
    public class Service : IService
    {
        public string GetString()
        {
            return "hello";
        }
    }
}