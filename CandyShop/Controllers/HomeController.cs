using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyShop.Models;
using CandyShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CandyShop.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepo _productRepo;

        public HomeController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                ProductsOfTheWeek = _productRepo.ProductOfTheWeek
            };

            return View(homeViewModel);
        }
    }
}
