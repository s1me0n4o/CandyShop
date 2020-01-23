using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyShop.Models;
using CandyShop.Models.Domains;
using CandyShop.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CandyShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private IOrderRepo _orderRepo;
        private ShopingCardRepo _shopingRepo;

        public OrderController(IOrderRepo orderRepo, ShopingCardRepo shopingRepo)
        {
            _orderRepo = orderRepo;
            _shopingRepo = shopingRepo;

        }


        public IActionResult CheckOut()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            
            var items = _shopingRepo.GetShopingCards();
            _shopingRepo.ShopingCards = items;
            if (_shopingRepo.ShopingCards.Count == 0)
            {
                ModelState.AddModelError("", "Your card is empty, please add some products.");
            }

            if (ModelState.IsValid)
            {
                _orderRepo.CreateOrder(order);
                _shopingRepo.ClearCard();
                return RedirectToAction("CheckOutComplete");
            }
            return View(order);
        }

        public IActionResult CheckOutComplete()
        {
            ViewBag.CheckOutCompleteMessage = "Thank you for your order! Your products will be delivered soon!";
            return View();
        }
    }
}
