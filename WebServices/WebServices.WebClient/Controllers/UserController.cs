using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebServices.Domain;
using System.Net.Http.Formatting;



namespace WebServices.WebClient.Controllers
{
    public class UserController : Controller
    {
        // GET: UserClient
        public ActionResult Index()
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("http://localhost:22644/");
            var request = clientHttp.GetAsync("api/User").Result;
            if (request.IsSuccessStatusCode)
            {
                var users = request.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<User>>(users);
                return View(list);
            }
            //clientHttp.PostAsync();
            //clientHttp.PutAsync();
            //clientHttp.DeleteAsync();
            return View();
        }

        //Always it is pair the first it is the view httpget and the second is the functionality httpX
        [HttpGet]
        public ActionResult Post ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Post(User user)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("http://localhost:22644/");
            var request = clientHttp.PostAsync("api/User", user, new JsonMediaTypeFormatter()).Result;
            if (request.IsSuccessStatusCode)
            {
                var users = request.Content.ReadAsStringAsync().Result;
                var userCreated = JsonConvert.DeserializeObject<bool>(users);
                if (userCreated)
                {
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            return View();
        }

        [HttpGet]
        public ActionResult Update(Guid id)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("http://localhost:22644/");
            var request = clientHttp.GetAsync("api/User?id=" + id).Result;
            if (request.IsSuccessStatusCode)
            {
                var users = request.Content.ReadAsStringAsync().Result;
                var user = JsonConvert.DeserializeObject<User>(users);
                return View(user);
            }
            return View();
        }

        [HttpPut]
        public ActionResult Update(User user)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("http://localhost:22644/");
            var request = clientHttp.PostAsync("api/User", user, new JsonMediaTypeFormatter()).Result;
            if (request.IsSuccessStatusCode)
            {
                var users = request.Content.ReadAsStringAsync().Result;
                var userCreated = JsonConvert.DeserializeObject<bool>(users);
                if (userCreated)
                {
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("http://localhost:22644/");
            var request = clientHttp.DeleteAsync("api/User?id=" + id).Result;
            if (request.IsSuccessStatusCode)
            {
                var users = request.Content.ReadAsStringAsync().Result;
                var isDeleted= JsonConvert.DeserializeObject<bool>(users);
                if (isDeleted)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Detail(Guid id)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("http://localhost:22644/");
            var request = clientHttp.GetAsync("api/User?id=" + id).Result;
            if (request.IsSuccessStatusCode)
            {
                var users = request.Content.ReadAsStringAsync().Result;
                var user = JsonConvert.DeserializeObject<User>(users);
                return View(user);
            }
            return View();
        }
    }
}