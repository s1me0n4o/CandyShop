using CandyShop.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models.Domains
{
    public class ShopingCard
    {
        public int Id { get; set; }
        public Products Products { get; set; }
        public int AmountOfProducts { get; set; }
        public string ShopingCardId { get; set; }
    }
}
