using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyShop.Models;
using CandyShop.Models.Interfaces;
using CandyShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CandyShop.Controllers
{
    public class ShopingCardController : Controller
    {
        private IProductRepo _productRepo;
        private ShopingCardRepo _shopingRepo;

        public ShopingCardController(ShopingCardRepo shopingRepo, IProductRepo productRepo)
        {
            _shopingRepo = shopingRepo;
            _productRepo = productRepo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var items = _shopingRepo.GetShopingCards();
            _shopingRepo.ShopingCards = items;

            var shopingCardViewModel = new ShopingCardViewModel
            {
                ShopingCard = _shopingRepo,
                ShopingCardTotal = _shopingRepo.GetTotalShopingCards()
            };
            return View(shopingCardViewModel);
        }

        public RedirectToActionResult AddToShopingCard(int id)
        {
            var selectedProduct = _productRepo.GetProductById(id);
            //var selectedProduct = _productRepo.AllProducts.FirstOrDefault(p => p.Id == productId);

            if (selectedProduct != null)
            {
                _shopingRepo.AddToCard(selectedProduct, 1);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShopingCard(int id)
        {
            var selectedProduct = _productRepo.AllProducts.FirstOrDefault(p => p.Id == id);

            if (selectedProduct != null)
            {
                _shopingRepo.RemoveFromCard(selectedProduct);
            }
                
            return RedirectToAction("Index");
        }
    }
}
