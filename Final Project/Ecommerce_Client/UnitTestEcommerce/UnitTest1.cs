//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ecommerce_Client.Models;
using Ecommerce_Client.Controllers.Admin_Panel;
using Ecommerce_Client.Controllers.Customer_Panel;
using System.Data.Entity;
using Moq;
using System.Web.Mvc;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace UnitTestEcommerce
{
    [TestFixture]
    public class Tests
    {
        private AdminLoginController _controller;
        private CustomerController _customerLoinController;
        private CustomerController _customer;
        private AdminCategoryController _admincatcontroller;
        private AdminProductsController _adminProductsController;
        private CustomerOrder _CustomerOrder;
        private Mock<EcommerceEntities> _mockContext;
        private Mock<DbSet<Admin>> _mockAdmins;
        private Mock<DbSet<Customer>> _mockEmployee;

        [SetUp]
        public void Setup()
        {
            // Initialize mocks
            _mockContext = new Mock<EcommerceEntities>();
            _mockAdmins = new Mock<DbSet<Admin>>();
            _mockEmployee = new Mock<DbSet<Customer>>();


            _controller = new AdminLoginController();
            _customerLoinController = new CustomerController();
            _customer = new CustomerController();
            _admincatcontroller = new AdminCategoryController();
            _adminProductsController = new AdminProductsController();
            _CustomerOrder = new CustomerOrder();
        }

        // Login Redirecting to its View
        [Test]
        public void Login_Get_ReturnsView()
        {
            var result = _controller.Login() as ViewResult;
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual("", result.ViewName);

        }
        [Test]
        public void Login_Get_EReturnsView()
        {
            var result = _customerLoinController.CustomerLogin() as ViewResult;
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual("", result.ViewName);

        }

        [Test]
        public void Login_Get_EReturnsVieW()
        {
            var result = _customer.Register() as ViewResult;
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual("", result.ViewName);

        }

        [Test]
        public void Login_Get_EReturnsViEW()
        {
            var result = _admincatcontroller.Create() as ViewResult;
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual("", result.ViewName);
        }

        [Test]
        public void Login_Get_EReTurnsViEW()
        {
            var result = _adminProductsController.Create() as ViewResult;
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual("", result.ViewName);
        }



    }
}