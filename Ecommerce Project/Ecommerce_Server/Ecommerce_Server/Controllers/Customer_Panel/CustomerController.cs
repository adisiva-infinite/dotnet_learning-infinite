using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ecommerce_Server.Models;

namespace Ecommerce_Server.Controllers.Customer_API
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        private readonly EcommerceEntities db = new EcommerceEntities();

        // GET: api/Customer
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllCustomers()
        {
            var customers = db.Customers.ToList();
            if (customers == null || !customers.Any())
            {
                return NotFound();
            }
            return Ok(customers);
        }

        // GET: api/Customer/{id}
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetCustomerById(int id)
        {
            var customer = db.Customers.FirstOrDefault(x => x.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST: api/Customer
        [HttpPost]
        [Route("")]
        public IHttpActionResult PostCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer data is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return Ok("Customer added successfully.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Customer/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            try
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
                return Ok("Customer deleted successfully.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Customer/Login?emailaddress={emailaddress}&password={password}
        [HttpGet]
        [Route("Login")]
        public IHttpActionResult Login(string emailaddress, string password)
        {
            if (string.IsNullOrWhiteSpace(emailaddress) || string.IsNullOrWhiteSpace(password))
            {
                return BadRequest("Email address and password are required.");
            }

            var login = db.Customers
                .Where(x => x.EmailAddress == emailaddress && x.Password == password)
                .Select(y => new
                {
                    y.CustomerId,
                    y.FullName
                })
                .SingleOrDefault();

            if (login == null)
            {
                return NotFound();
            }
            return Ok(login);
        }
    }
}