using OnlineShoppingStore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.UI.Controllers
{
    public class NavigationController : Controller
    {
        public IProductRepository productRepository;
        public NavigationController(IProductRepository repository)
        {
            productRepository = repository;
        }

        // GET: Navigation
        public PartialViewResult CategoryMenu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            var categories = productRepository.products
                            .Select(p => p.Category)
                            .Distinct().OrderBy(x => x);
            return PartialView(categories);
        }
    }
}