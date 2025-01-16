using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Ecommerce_Client.Models;

namespace Ecommerce_Client.Controllers.Customer_Panel
{
    public class CustomerController : Controller
    {
        private readonly EcommerceEntities db = new EcommerceEntities();
        // GET: Customer
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                // Log the exception
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                return new HttpStatusCodeResult(500, "An error occurred while loading the login page.");
            }
        }

        // GET: Register
        [HttpGet]
        public ActionResult Register()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                // Log the exception
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                return new HttpStatusCodeResult(500, "An error occurred while loading the registration page.");
            }
        }

        // POST: Register
        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(customer);
                }

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44307/api");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PostAsJsonAsync("api/Customer", customer).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        // Registration successful
                        ViewBag.Result = "Registration successful.";
                        return RedirectToAction("CustomerLogin");
                    }
                    else
                    {
                        // Handle registration failure
                        ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
                        return View(customer);
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                // Log HTTP request exception
                System.Diagnostics.Debug.WriteLine($"HTTP Error: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while communicating with the server. Please try again later.");
                return View(customer);
            }
            catch (Exception ex)
            {
                // Log general exception
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again later.");
                return View(customer);
            }
        }

        [HttpGet]
        public ActionResult CustomerLogin()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                // Log the exception
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                return new HttpStatusCodeResult(500, "An error occurred while loading the login page.");
            }
        }

        // POST: Login
        [HttpPost]
        public ActionResult CustomerLogin(Customer loginCustomer)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44307/api/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string loginUrl = $"Customer/Login?emailaddress={HttpUtility.UrlEncode(loginCustomer.EmailAddress)}&password={HttpUtility.UrlEncode(loginCustomer.Password)}";
                    HttpResponseMessage response = client.GetAsync(loginUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = response.Content.ReadAsAsync<dynamic>().Result;

                        int customerId = responseData.CustomerId;
                        string fullName = responseData.FullName;

                        System.Diagnostics.Debug.WriteLine($"Login Successful! CustomerId: {customerId}, FullName: {fullName}");

                        Session["CustomerId"] = customerId;
                        Session["FullName"] = fullName;
                      //  Session["Role"] = "Customer";

                        return RedirectToAction("Index", "CustomerDashBoard");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid email address or password. Please try again.");
                        return View(loginCustomer);
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                // Log HTTP request exception
                System.Diagnostics.Debug.WriteLine($"HTTP Error: {ex.Message}");
                ModelState.AddModelError(string.Empty, "A problem occurred while communicating with the server. Please try again later.");
                return View(loginCustomer);
            }
            catch (Exception ex)
            {
                // Log general exception
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again later.");
                return View(loginCustomer);
            }
        }

        // GET: Signout
        public ActionResult Signout()
        {
            try
            {
                Session["CustomerId"] = null;
                Session["FullName"] = null;
                Session["Admin_Id"] = null;
                Session["FullName"] = null;
                //   Session["CartId"] = null;

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                // Log the exception
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                return new HttpStatusCodeResult(500, "An error occurred while signing out.");
            }
        }
    }
}