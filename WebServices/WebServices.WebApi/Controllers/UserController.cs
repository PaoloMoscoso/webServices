using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServices.Data.Models;

namespace WebServices.WebApi.Controllers
{
    public class UserController : ApiController
    {
        LibraryConnection DB = new LibraryConnection();
        
        //<summary>
        // return all users 
        //</summary>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            var list = DB.Users.ToList();
            return list;
        }
        //<summary>
        // return user by id
        //</summary>
        [HttpGet]
        public User Get(Guid id)
        {
            var foundUser = DB.Users.FirstOrDefault(user => user.Id == id);
            return foundUser;
        }

        [HttpPost]
        public bool Post(User user)
        {
            DB.Users.Add(user);
            return DB.SaveChanges() > 0;
        }

        [HttpPut]
        public bool Put(User user)
        {
            var foundUser = DB.Users.FirstOrDefault(x => x.Id == user.Id);
            foundUser.FirstName = user.FirstName.Trim();
            foundUser.LastName = user.LastName.Trim();
            foundUser.LogOnName = user.LogOnName;
            foundUser.PasswordHash = user.PasswordHash.Trim();
            foundUser.PasswordChangedDate = user.PasswordChangedDate;
            foundUser.IsEnabled = user.IsEnabled;
            foundUser.ExpiryDate = user.ExpiryDate;
            return DB.SaveChanges() > 0;
        }
        [HttpDelete]
        public bool Delete(Guid id)
        {
            var foundUser = DB.Users.FirstOrDefault(user => user.Id == id);
            DB.Users.Remove(foundUser);
            return DB.SaveChanges() > 0;
        }
    }
}
