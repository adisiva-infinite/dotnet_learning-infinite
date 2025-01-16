using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Ecommerce_Client.Models;

namespace Ecommerce_Client.Controllers.Admin_Panel
{
    public class AdminLoginController : Controller
    {
        private readonly EcommerceEntities db = new EcommerceEntities();

        // GET: AdminLogin
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

        [HttpGet]
        public ActionResult Login()
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

        [HttpPost]
        public ActionResult Login(Admin Adminlogin)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44307/api/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string loginUrl = $"Admin/Login?emailaddress={HttpUtility.UrlEncode(Adminlogin.Email_Address)}&password={HttpUtility.UrlEncode(Adminlogin.Password)}";

                    HttpResponseMessage response = client.GetAsync(loginUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = response.Content.ReadAsAsync<dynamic>().Result;
                        string Adminid = responseData.Admin_Id;
                        string fullName = responseData.Email_Address;

                        Session["Admin_Id"] = Adminid;
                        Session["Email_Address"] = fullName;
                    //    Session["Role"] = "Admin";


                        return RedirectToAction("Index", "AdminDashBoard");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid email address or password. Please try again.");
                        return View(Adminlogin);
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                // Log the exception for HTTP request issues
                System.Diagnostics.Debug.WriteLine($"HTTP Error: {ex.Message}");
                ModelState.AddModelError(string.Empty, "A problem occurred while communicating with the server. Please try again later.");
                return View(Adminlogin);
            }
            catch (Exception ex)
            {
                // Log the exception for general issues
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again later.");
                return View(Adminlogin);
            }
        }

        public ActionResult Signout()
        {
            try
            {
                // Clear the session variables
                Session["Admin_Id"] = null;
                Session["FullName"] = null;

                // Optionally, you could redirect to the login page after signing out
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