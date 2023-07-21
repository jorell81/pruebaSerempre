using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace PruebaSerempre
{
    internal class Program
    {
        static async Task Main()
        {
            try
            {
                string url = "https://raw.githubusercontent.com/Serempre/test-json/main/list1.json";

                using (HttpClient client = new HttpClient())
                {

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContenido = await response.Content.ReadAsStringAsync();


                        List<User> jsonObjetos = JsonConvert.DeserializeObject<List<User>>(jsonContenido);

                        
                        List<User> sortedUsers = jsonObjetos.OrderBy(u => u.Kpi.Speed).ToList();

                        foreach (var user in sortedUsers)
                        {
                            
                            Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Speed: {user.Kpi.Speed}");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }


                }
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }
    }
    public class Kpi
    {
        public int Speed { get; set; }
        public int Level { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Kpi Kpi { get; set; }
    }
}