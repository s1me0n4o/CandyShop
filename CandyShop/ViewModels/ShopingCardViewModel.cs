using CandyShop.Models;
using CandyShop.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.ViewModels
{
    public class ShopingCardViewModel
    {
        public ShopingCardRepo ShopingCard { get; set; }
        public decimal ShopingCardTotal { get; set; }
    }
}
