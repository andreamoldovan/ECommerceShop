using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ECommerceShop.Data;

namespace ECommerceShop.Models
{
    public class CoffeeCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(ECommerceShopContext context,
        Coffee coffee)
        {
            var allCategories = context.Category;
            var coffeeCategories = new HashSet<int>(
            coffee.CoffeeCategories.Select(c => c.CoffeeID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = coffeeCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateCoffeeCategories(ECommerceShopContext context,
        string[] selectedCategories, Coffee coffeeToUpdate)
        {
            if (selectedCategories == null)
            {
                coffeeToUpdate.CoffeeCategories = new List<CoffeeCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var coffeeCategories = new HashSet<int>
            (coffeeToUpdate.CoffeeCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!coffeeCategories.Contains(cat.ID))
                    {
                        coffeeToUpdate.CoffeeCategories.Add(
                        new CoffeeCategory
                        {
                            CoffeeID = coffeeToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (coffeeCategories.Contains(cat.ID))
                    {
                        CoffeeCategory courseToRemove
                        = coffeeToUpdate
                        .CoffeeCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
    }

