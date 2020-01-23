using CandyShop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models.Domains
{
    public class OrderRepo : IOrderRepo
    {
        private IShopingRepo _shopingCard;
        private DatabaseContext _databaseContext;

        public OrderRepo(IShopingRepo shopingCard, DatabaseContext databaseContext)
        {
            _shopingCard = shopingCard;
            _databaseContext = databaseContext;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.UtcNow;

            _databaseContext.Orders.Add(order);

            //todo check
            var shopingCards = _shopingCard.GetShopingCards();

            foreach (var card in shopingCards)
            {
                var orderDetails = new OrderDetails
                {
                    Id = order.Id,
                    Amount = card.AmountOfProducts,
                    ProductId = card.Products.Id,
                    Price = card.Products.Price
                };
                _databaseContext.OrderDetails.Add(orderDetails);

                _databaseContext.SaveChanges();
            }
        }
    }
}
