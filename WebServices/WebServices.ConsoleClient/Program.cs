using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebServices.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            /*HttpClient client= new HttpClient();
            client.BaseAddress = new Uri("http://localhost:22644/");
            var request = client.GetAsync("api/User").Result;
            if (request.IsSuccessStatusCode)
            {
                var resulString = request.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<User>>(resulString);
                foreach(var user in list )
                {
                    Console.WriteLine(user.FirstName);
                }
                Console.ReadLine();
            }*/
            //client.PostAsync();
            //client.PutAsync();
            //client.DeleteAsync();
        }
    }
}
