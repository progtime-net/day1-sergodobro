using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_For_Git
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! What is your name, user?");
            var name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}! Welcome to our world!");
            Console.ReadLine();
        }
    }
}
