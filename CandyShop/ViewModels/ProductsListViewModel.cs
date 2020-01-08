using CandyShop.Domains.Models;
using System.Collections.Generic;

namespace CandyShop.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Products> Products { get; set; }
        public string CurrentCategory { get; set; }
    }
}
