using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Domains.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string  LongDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageTumbnailUrl { get; set; }
        public bool IsProductOfTheWeek { get; set; }
        public Category Category { get; set; }
    }
}
