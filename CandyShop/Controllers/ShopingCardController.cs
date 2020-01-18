using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CandyShop.Controllers
{
    public class ShopingCardController : Controller
    {
        private IProductRepo _productRepo;
        private IShopingRepo _shopingRepo;

        public ShopingCardController(IShopingRepo _shopingRepo, IProductRepo productRepo)
        {
            _shopingRepo = _shopingRepo;
            _productRepo = productRepo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
