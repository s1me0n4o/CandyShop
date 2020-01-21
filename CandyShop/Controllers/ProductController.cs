using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyShop.ViewModels;
using CandyShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CandyShop.Domains.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CandyShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo _productRepo;
        private readonly ICategoryRepo _categoryRepo;

        public ProductController(IProductRepo productRepo, ICategoryRepo categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }

        //In Order to view dropdown in the nav bar witch filter out products remove this ListOfProducts > use components
        //public ViewResult ListOfProducts()
        //{
        //    ProductsListViewModel plvm = new ProductsListViewModel();
        //    plvm.Products = _productRepo.AllProducts;

        //    plvm.CurrentCategory = "Cheese Cake";
        //    return View(plvm);
        //}
        
        public ViewResult ListOfProducts(string category)
        {
            IEnumerable<Products> products;
            string currentCattegory;

            if (string.IsNullOrEmpty(category))
            {
                products = _productRepo.AllProducts.OrderBy(p => p.Id);
                currentCattegory = "All products";
            }
            else
            {
                products = _productRepo.AllProducts.Where(p => p.Category.CategoryName == category)
                                                .OrderBy(p => p.Id);
                currentCattegory = _categoryRepo.AllCategories.FirstOrDefault(c => c.CategoryName == category).ToString();
            }

            return View(new ProductsListViewModel
            {
                Products = products,
                CurrentCategory = currentCattegory
            });
        }
        public IActionResult Details(int id)
        {
            var product = _productRepo.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
