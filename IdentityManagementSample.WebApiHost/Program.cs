using IdentityManagementSample.WebApiCore;
using System;

namespace IdentityManagementSample.WebApiHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var srv = new WebApiService();

            srv.Start("http://localhost:9005");

            Console.WriteLine("Web API is running...");
            Console.ReadKey();
        }
    }
}