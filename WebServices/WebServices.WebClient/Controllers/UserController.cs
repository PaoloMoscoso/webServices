using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebServices.Domain;

namespace WebServices.WebClient.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:22644/");
            var request = client.GetAsync("api/User").Result;
            if (request.IsSuccessStatusCode)
            {
                var resulString = request.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<User>>(resulString);
                return View(list);
            }
            //client.PostAsync();
            //client.PutAsync();
            //client.DeleteAsync();
            return View();
        }
    }
}