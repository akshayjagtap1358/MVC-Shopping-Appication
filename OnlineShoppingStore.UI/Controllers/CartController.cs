using OnlineShoppingStore.Domain.Entities;
using OnlineShoppingStore.Domain.Repository;
using OnlineShoppingStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.UI.Controllers
{
    public class CartController : Controller
    {
        public IProductRepository productRepository;
        public IOrderProcesser orderProcesser;

        public CartController(IProductRepository repository, IOrderProcesser processer)
        {
            productRepository = repository;
            orderProcesser = processer;
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            var product = productRepository.products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            var product = productRepository.products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                cart.RemoveItem(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel()
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if(cart.CartLines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, Your cart is empty :-(");
            }
            if (ModelState.IsValid)
            {
                orderProcesser.ProcessOrder(cart, shippingDetails);
                cart.ClearItems();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
    }
}