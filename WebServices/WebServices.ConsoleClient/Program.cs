using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebServices.Data.Models;

namespace WebServices.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("http://localhost:22644/");
            var request = clientHttp.GetAsync("api/User").Result;
            if(request.IsSuccessStatusCode)
            {
                var users = request.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<User>>(users);
                foreach( var user in list)
                {
                    Console.WriteLine("forEeach");
                    Console.WriteLine(user.FirstName);
                }
                Console.ReadLine();
            }
            //clientHttp.PostAsync();
            //clientHttp.PutAsync();
            //clientHttp.DeleteAsync();
        }
    }
}
