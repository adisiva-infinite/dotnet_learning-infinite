﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce_Client.Models;

namespace Ecommerce_Client.Controllers.Customer_Panel
{
    public class CartController : Controller
    {
        EcommerceEntities db = new EcommerceEntities();

        // Get cart
        public ActionResult Cart()
        {
            if (Session["CustomerId"] == null || Session["Role"]?.ToString() == "Admin")
            {
                ViewBag.Message = "You do not have access to the shopping cart until you login as Customer...!";
                return View("AccessDenied");
            }

            if (Session["CustomerId"] == null)
            {
                return RedirectToAction("Login", "CustomerLogin");
            }

            int customerId = (int)Session["CustomerId"];
            Guid cartId;

            if (Session["CartId"] == null)
            {
                var existingCart = db.ShoppingCarts.FirstOrDefault(c => c.Customerid == customerId);
                if (existingCart != null)
                {
                    cartId = existingCart.CartId; 
                    Session["CartId"] = cartId;   
                }
                else
                {
                    cartId = Guid.NewGuid();     
                    Session["CartId"] = cartId;
                }
            }
            else
            {
                cartId = (Guid)Session["CartId"];
            }

            var cartItems = db.ShoppingCarts
                .Where(c => c.CartId == cartId && c.Customerid == customerId)
                .ToList();

            return View(cartItems);
        }

        [HttpPost]
        public ActionResult AddToCart(int productId, int quantity)
        {
            try
            {
                if (Session["CustomerId"] == null)
                {
                    return RedirectToAction("Login", "CustomerLogin");
                }

                int customerId = (int)Session["CustomerId"];
                Guid cartId;

                if (Session["CartId"] == null)
                {
                    var existingCart = db.ShoppingCarts.FirstOrDefault(c => c.Customerid == customerId);
                    if (existingCart != null)
                    {
                        cartId = existingCart.CartId;
                    }
                    else
                    {
                        cartId = Guid.NewGuid(); // Generate a new CartId
                    }

                    // Store CartId in the session
                    Session["CartId"] = cartId;
                }
                else
                {
                    cartId = (Guid)Session["CartId"];
                }

                var cartItem = db.ShoppingCarts.FirstOrDefault(c => c.ProductId == productId && c.CartId == cartId && c.Customerid == customerId);

                if (cartItem != null)
                {
                    cartItem.Quantity += quantity;
                }
                else
                {
                    db.ShoppingCarts.Add(new ShoppingCart
                    {
                        CartId = cartId,
                        Customerid = customerId,
                        ProductId = productId,
                        Quantity = quantity,
                        DateCreated = DateTime.Now
                    });
                }

                db.SaveChanges();
                return RedirectToAction("Cart");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error adding product to cart: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while adding the item to the cart.");
                return View();
            }
        }

        // POST: Update Cart
        [HttpPost]
        public ActionResult UpdateCart(int recordId, int quantity)
        {
            var cartItem = db.ShoppingCarts.Find(recordId);

            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                db.SaveChanges();
            }

            return RedirectToAction("Cart");
        }

        // POST: Remove from Cart
        [HttpPost]
        public ActionResult RemoveFromCart(int recordId)
        {
            var cartItem = db.ShoppingCarts.Find(recordId);

            if (cartItem != null)
            {
                db.ShoppingCarts.Remove(cartItem);
                db.SaveChanges();
            }

            return RedirectToAction("Cart");
        }

        public ActionResult Checkout()
        {
            if (Session["CartId"] == null || Session["CustomerId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            Guid cartId = (Guid)Session["CartId"];
            int customerId = (int)Session["CustomerId"];

            var cartItems = db.ShoppingCarts.Where(c => c.CartId == cartId && c.Customerid == customerId).ToList();
            if (cartItems.Count == 0)
            {
                ViewBag.Message = "Your cart is empty.";
                return RedirectToAction("Cart");
            }

            var order = new Order
            {
                CustomerId = customerId,
                OrderDate = DateTime.Now,
                ShipDate = DateTime.Now.AddDays(7)
            };
            db.Orders.Add(order);
            db.SaveChanges();

            foreach (var item in cartItems)
            {
                // Add order details
                db.OrderDetails.Add(new OrderDetail
                {
                    OrderId = order.OrderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitCost = db.Products.Find(item.ProductId).UnitCost
                });

                // Decrease stock for the product
                var product = db.Products.Find(item.ProductId);
                if (product != null)
                {
                    if (product.Stock >= item.Quantity)
                    {
                        product.Stock -= item.Quantity;
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, $"Insufficient stock for product: {product.ProductName}");
                        return RedirectToAction("Cart");
                    }
                }
                db.ShoppingCarts.Remove(item);
            }

            db.SaveChanges();
            Session["CartId"] = Guid.NewGuid();

            return RedirectToAction("OrderConfirmation");
        }

        // GET: Order Confirmation
        public ActionResult OrderConfirmation()
        {
            return View();
        }
    }
}