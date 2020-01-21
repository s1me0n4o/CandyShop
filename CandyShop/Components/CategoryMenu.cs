using CandyShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Components
{
    public class CategoryMenu : ViewComponent
    {
        private ICategoryRepo _category;

        public CategoryMenu(ICategoryRepo category)
        {
            _category = category;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _category.AllCategories.OrderBy(c => c.CategoryName);
            return View(categories);
        }
    }
}
