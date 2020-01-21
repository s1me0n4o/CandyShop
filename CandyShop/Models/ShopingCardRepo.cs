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
        public string ShoppingCardId { get; set; }

        public List<ShopingCard> ShopingCards = new List<ShopingCard>();

        public ShopingCardRepo (DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public static ShopingCardRepo GetCard(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<DatabaseContext>();
           
            string cardId = session.GetString("CardId") ?? Guid.NewGuid().ToString();

            session.SetString("CardId", cardId);

            return new ShopingCardRepo(context) { ShoppingCardId = cardId };
        }

        public void AddToCard(Products product, int amountOfProducts)
        {
            var shopingCard = 
                _databaseContext.ShopingCard.SingleOrDefault(s => s.Products.Id == product.Id && 
                                                            s.ShopingCardId == ShoppingCardId);
            if (shopingCard == null)
            {
                shopingCard = new ShopingCard
                {
                    ShopingCardId = ShoppingCardId,
                    Products = product,
                    AmountOfProducts = 1
                };

                _databaseContext.ShopingCard.Add(shopingCard);
            }
            else
            {
                shopingCard.AmountOfProducts++;
            }
            _databaseContext.SaveChanges();
        }

        public int RemoveFromCard(Products product)
        {
            var shopingCard = _databaseContext.ShopingCard.SingleOrDefault(s => s.Products.Id == product.Id && s.ShopingCardId == ShoppingCardId);

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
            //shopingCardsItems are empty TODO check.
            //return ShopingCards ?? 
            //             (ShopingCards = 
            //                _databaseContext.ShopingCard.Where(c => c.ShopingCardId == ShoppingCardId)
            //                    .Include(s => s.Products)
            //                    .ToList());

            if (ShopingCards.Count == 0 || ShopingCards == null)
            {
                ShopingCards = _databaseContext.ShopingCard.Where(c => c.ShopingCardId == ShoppingCardId).Include(s => s.Products).ToList();
            }
            return ShopingCards;
        }

        public void ClearCard()
        {
            var cartItems = _databaseContext.ShopingCard.Where(carts => carts.ShopingCardId == ShoppingCardId);

            _databaseContext.ShopingCard.RemoveRange(cartItems);

            _databaseContext.SaveChanges();
        }

        public decimal GetTotalShopingCards()
        {
            var result = _databaseContext.ShopingCard.Where(c => c.ShopingCardId == ShoppingCardId)
                                                .Select(c => c.Products.Price * c.AmountOfProducts).Sum();
            return result;
        }
    }
}
