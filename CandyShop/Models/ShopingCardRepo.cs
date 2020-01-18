using CandyShop.Domains.Models;
using CandyShop.Models.Domains;
using CandyShop.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class ShopingCardRepo : IShopingRepo
    {
        private DatabaseContext _databaseContext;
        public string _shoppingCardIdKey;
        public List<ShopingCard> ShopingCards = new List<ShopingCard>();

        public ShopingCardRepo (DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public static ShopingCardRepo GetCard(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<DatabaseContext>();
           
            string cardKey = session.GetString("Id") ?? Guid.NewGuid().ToString();

            session.SetString("Id", cardKey);

            return new ShopingCardRepo(context) { _shoppingCardIdKey = cardKey };
        }

        public void AddToCard(Products product, int amountOfProducts)
        {
            var shopingCard = _databaseContext.ShopingCardItems.SingleOrDefault(s => s.Products.Id == product.Id && s.ShopingCardKey == _shoppingCardIdKey);
            if (shopingCard == null)
            {
                shopingCard = new ShopingCard
                {
                    ShopingCardKey = _shoppingCardIdKey,
                    Products = product,
                    AmountOfProducts = 1
                };

                _databaseContext.ShopingCardItems.Add(shopingCard);
            }
            else
            {
                shopingCard.AmountOfProducts++;
            }
            _databaseContext.SaveChanges();
        }

        public int RemoveFromCard(Products product)
        {
            var shopingCard = _databaseContext.ShopingCardItems.SingleOrDefault(s => s.Products.Id == product.Id && s.ShopingCardKey == _shoppingCardIdKey);

            var localAmount = 0;
            if (shopingCard == null)
            {
                if (shopingCard.AmountOfProducts > 1)
                {
                    shopingCard.AmountOfProducts--;
                    localAmount = shopingCard.AmountOfProducts;
                }
                else
                {
                    _databaseContext.Remove(shopingCard);
                }
            }
            _databaseContext.SaveChanges();

            return localAmount;
        }

        public List<ShopingCard> GetShopingCards()
        {
            return ShopingCards ?? 
                            (ShopingCards = _databaseContext.ShopingCardItems.Where(c => c.ShopingCardKey == _shoppingCardIdKey)
                                .Include(s => s.Products).ToList());
        }

        public void ClearCard()
        {
            var cartItems = _databaseContext.ShopingCardItems.Where(carts => carts.ShopingCardKey == _shoppingCardIdKey);

            _databaseContext.ShopingCardItems.RemoveRange(cartItems);

            _databaseContext.SaveChanges();
        }

        public decimal GetTotalShopingCards()
        {
            var result = _databaseContext.ShopingCardItems.Where(c => c.ShopingCardKey == _shoppingCardIdKey)
                                                .Select(c => c.Products.Price * c.AmountOfProducts).Sum();
            return result;
        }
    }
}
