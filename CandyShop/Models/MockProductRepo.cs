using CandyShop.Models.Interfaces;
using CandyShop.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class MockProductRepo : IProductRepo
    {
        private readonly ICategoryRepo _categoryRepo = new MockCategoryRepo();
        
        
        public IEnumerable<Products> AllProducts =>
            new List<Products>
            {
                new Products {Id= 1 , Name ="Jingle Bells", Price = 15.95M, ShortDescription = "Lorem birem", ImageTumbnailUrl = "/Images/carousel3.jpg" , Category = new Category{CategoryId = 1, CategoryName = "1 pies", Description = "All-fruity pies" }},
                new Products {Id= 2 , Name ="Marry Christmas", Price = 16.95M, ShortDescription = "Lorem harem", ImageTumbnailUrl = "/Images/carousel2.jpg" , Category = new Category{CategoryId = 2, CategoryName = "2 pies", Description = "All-fruity pies" }},
                new Products {Id= 3 , Name ="Happy New Year", Price = 21.95M, ShortDescription = "Lorem selem", ImageTumbnailUrl = "/Images/carousel1.jpg" , Category = new Category{CategoryId = 3, CategoryName = "3 pies", Description = "All-fruity pies" }},
                new Products {Id= 4 , Name ="Rapuncel", Price = 13.95M, ShortDescription = "Lorem idem" , ImageTumbnailUrl = "/Images/carousel1.jpg", Category = new Category{CategoryId = 4, CategoryName = "4 pies", Description = "All-fruity pies" }}
            };

        public IEnumerable<Products> ProductOfTheWeek { get; }

        public Products GetProductById(int productId)
        {
            return AllProducts.FirstOrDefault(p => p.Id == productId);
        }

        Products IProductRepo.GetProductById(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
