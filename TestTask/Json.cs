using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;

namespace TestTask
{
    internal static class Json
    {
        public static JsonData Deserialize()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("https://api.kontur.ru/dc.contacts/v1/cus").Result;
                var file = response.Content.ReadAsStringAsync().Result;
                var json = JsonSerializer.Deserialize<JsonData>(file);
                return json;
            }
        }

        public static JsonData RegionSort(JsonData json, string region)
        {
            List<Cu> list = new List<Cu>();
            for (int i = 0; i < json.cus.Length; i++)
            {
                if (json.cus[i].region == region)
                {
                    list.Add(json.cus[i]);
                }
            }
            var sortedJson = new JsonData() { cus = new Cu[list.Count] };
            sortedJson.cus = list.ToArray();
            return sortedJson;
        }

        public static List<Cu> CodeSort(JsonData json)
        {
            return json.cus.OrderByDescending(x => x.type)
                .ThenBy(x => x.code)
                .ToList();
        }

        public static Dictionary<string, int> GetDictTypes(List<Cu> list)
        {
            var types = new Dictionary<string, int>();
            foreach (var item in list)
            {
                if (!types.ContainsKey(item.type) && item.type != null)
                    types.Add(item.type, 1);
                else
                    types[item.type]++;
            }
            return types;
        }
    }
}
