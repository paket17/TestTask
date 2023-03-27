using System;
using System.Collections.Generic;
using System.Linq;

namespace TestTask
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Получаем данные...");
            var json = Json.Deserialize();
            var urJson = Json.RegionSort(json, "18");
            var sortedJson = Json.CodeSort(urJson);
            var types = Json.GetDictTypes(sortedJson);

            Console.WriteLine("Создаем Word документ...");
            WordWriter.WriteParagraph("Список контролирующих органов", bold: true, fontSize: 20);
            WordWriter.WriteParagraph($"Дата выполнения: {DateTime.Now.ToString("f")}\n" +
                $"Количество контролирующих органов:\n" +
                $"Общее – {sortedJson.Count}");
            foreach (var type in types)
                WordWriter.WriteParagraph($"{type.Key} - {type.Value}");
            WordWriter.WriteTable(sortedJson);
            WordWriter.Close();

            Console.WriteLine("\nДля выхода из программы нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
