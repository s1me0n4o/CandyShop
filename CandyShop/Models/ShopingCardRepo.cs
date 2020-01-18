using CandyShop.Domains.Models;
using CandyShop.Models.Domains;
using CandyShop.Models.Interfaces;
using Microsoft.AspNetCore.Http;
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
        public string ShoppingCardIdKey;

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

            return new ShopingCardRepo(context) { ShoppingCardIdKey = cardKey };
        }

        public void AddToCard(Products product, int amountOfProducts)
        {

        }
    }
}
