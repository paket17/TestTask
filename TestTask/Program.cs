using System;
using System.Collections.Generic;
using System.Linq;

namespace TestTask
{
    public class Program
    {
        public static void Main()
        {
            var json = Json.Deserialize();

            Console.WriteLine("test");
            Console.WriteLine("\nДля выхода из программы нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}