using CandyShop.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Products> ProductsOfTheWeek  { get; set; }
    }
}
