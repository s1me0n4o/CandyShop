using CandyShop.Domains.Models;
using CandyShop.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models.Interfaces
{
    public interface IShopingRepo
    {
        void AddToCard(Products products, int amount);
        decimal GetTotalShopingCards();

        void ClearCard();

        List<ShopingCard> GetShopingCards();
        int RemoveFromCard(Products product);

    }
}
