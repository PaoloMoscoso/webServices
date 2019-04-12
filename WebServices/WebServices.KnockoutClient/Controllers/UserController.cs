using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServices.Domain;
using System.Net.Http;
using Newtonsoft.Json;

namespace WebServices.KnockoutClient.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        
        // GET: User/Details/
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: User/Edit/5
        public ActionResult Edit(Guid id)
        {
            ViewBag.selectedUser = id;
            return View();
        }

        // GET: User/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }
    }
}
