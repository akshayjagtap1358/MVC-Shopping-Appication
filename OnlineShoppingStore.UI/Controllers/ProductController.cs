using OnlineShoppingStore.Domain.Repository;
using OnlineShoppingStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private const int pageSize = 4;
        public ProductController()
        {

        }
        public ProductController(IProductRepository repository)
        {
            productRepository = repository;
        }
        // GET: Product
        public ViewResult ProductsList(int page = 1)
        {
            PagingViewModel pagingViewModel = new PagingViewModel
            {
                Products = productRepository.products
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = productRepository.products.Count()
                }
            };
            return View(pagingViewModel);
        }

        public ViewResult ProductsListByCategory(string category, int page = 1)
        {
            var cate = category.Trim();
            PagingViewModel pagingViewModel = new PagingViewModel
            {
                Products = productRepository.products
                .Where(p => p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = productRepository.products.Where(p => p.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(pagingViewModel);
        }
    }
}