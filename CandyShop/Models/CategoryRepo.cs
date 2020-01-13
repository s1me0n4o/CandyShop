using CandyShop.Domains.Models;
using CandyShop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class CategoryRepo : ICategoryRepo
    {
        private DatabaseContext _databaseContext;

        public CategoryRepo(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IEnumerable<Category> AllCategories => _databaseContext.Categories;
    }
}
