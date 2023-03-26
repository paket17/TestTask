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
            var urJson = Json.RegionSort(json, "18");
            var sortedJson = Json.CodeSort(urJson);
            var types = Json.GetDictTypes(sortedJson);

            Console.WriteLine("\nДля выхода из программы нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
