using CandyShop.Domains.Models;
using CandyShop.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class ProductRepo : IProductRepo
    {
        private readonly DatabaseContext _databaseContext;

        public ProductRepo(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<Products> AllProducts
        {
            get
            {
                return _databaseContext.Products.Include(c => c.Category);
            }
        }

        public IEnumerable<Products> ProductOfTheWeek
        {
            get
            {
                return _databaseContext.Products.Include(c => c.Category).Where(p => p.IsProductOfTheWeek);
            }
        }

        public Products GetProductById(int productId)
        {
            return _databaseContext.Products.FirstOrDefault(p => p.Id == productId);
        }
    }
}
