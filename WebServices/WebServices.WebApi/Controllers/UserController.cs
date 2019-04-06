using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServices.Data.Model;

namespace WebServices.WebApi.Controllers
{
    public class UserController : ApiController
    {

        EdgeTrainingEntities Db = new EdgeTrainingEntities();
        [HttpGet]
        public IEnumerable<User> Get ()
        {
            var list = Db.Users.ToList();
            return list;
        }

        [HttpGet]
        public User Get(Guid id)
        {
            var foundUser = Db.Users.FirstOrDefault(user => user.Id == id);
            return foundUser;
        }
        [HttpPost]
        public bool Post(User user)
        {
            Db.Users.Add(user);
            return Db.SaveChanges() > 0;
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
