using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ecommerce_Server.Models;

namespace Ecommerce_Server.Controllers.Admin_API
{
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        EcommerceEntities db = new EcommerceEntities();

        public IEnumerable<Admin> Get()
        {
            return db.Admins.ToList();
        }

        public Admin Get(int id)
        {
            return db.Admins.FirstOrDefault(x => x.Admin_Id == id);
        }

        [HttpGet]
        [Route("Login")]
        public IHttpActionResult Login(string emailaddress, string password)
        {
            var Login = db.Admins
                .Where(x => x.Email_Address == emailaddress && x.Password == password)
                .Select(y => new { y.Admin_Id, y.Email_Address })
                .SingleOrDefault();

            if (Login != null)
            {
                return Ok(Login);
            }
            else
            {
                return NotFound();
            }
        }


    }
}
