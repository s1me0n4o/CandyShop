using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyShop.ViewModels;
using CandyShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        public ViewResult ListOfProducts()
        {
            ProductsListViewModel plvm = new ProductsListViewModel();
            plvm.Products = _productRepo.AllProducts;

            plvm.CurrentCategory = "Cheese Cake";
            return View(plvm);
        }
        
    }
}
