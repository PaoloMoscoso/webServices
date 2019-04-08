using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebServices.Data.Models;// reference

namespace WebServices.ASMXService
{
    /// <summary>
    /// Summary description for ASMXServiceUser
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ASMXServiceUser : System.Web.Services.WebService
    {
        LibraryConnection DB = new LibraryConnection();

        [WebMethod]
        public List<User> getUsers()
        {
            var list = DB.Users.ToList();
            return list;
        }
    }
}
