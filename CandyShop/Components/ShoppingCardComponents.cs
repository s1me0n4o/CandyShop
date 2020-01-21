using CandyShop.Models;
using CandyShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Components
{
    public class ShoppingCardComponents : ViewComponent
    {
        private ShopingCardRepo _shopingCardRepo;

        public ShoppingCardComponents(ShopingCardRepo shopingCardRepo)
        {
            _shopingCardRepo = shopingCardRepo;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shopingCardRepo.GetShopingCards();
            _shopingCardRepo.ShopingCards = items;

            var shopingCardViewModel = new ShopingCardViewModel
            {
                ShopingCard = _shopingCardRepo,
                ShopingCardTotal = _shopingCardRepo.GetTotalShopingCards()
            };
            return View(shopingCardViewModel);

        }
    }
}
