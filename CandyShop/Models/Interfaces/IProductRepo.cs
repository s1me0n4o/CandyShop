using CandyShop.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models.Interfaces
{
    public interface IProductRepo
    {
        IEnumerable<Products> AllProducts { get; }
        IEnumerable<Products> ProductOfTheWeek{ get; }
        Products GetProductById(int productId);

    }
}
