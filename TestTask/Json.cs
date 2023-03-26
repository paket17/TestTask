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
        public static Rootobject Deserialize()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("https://api.kontur.ru/dc.contacts/v1/cus").Result;
                var file = response.Content.ReadAsStringAsync().Result;
                var json = JsonSerializer.Deserialize<Rootobject>(file);
                return json;
            }
        }
    }
}
