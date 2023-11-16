using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace WCFServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Server s1 = new Server();
            s1.Start();
            Console.WriteLine("Okay!");
            Console.ReadKey();
        }
    }
}
