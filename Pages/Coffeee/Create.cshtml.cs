using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ECommerceShop.Data;
using ECommerceShop.Models;

namespace ECommerceShop.Pages.Coffeee
{
    public class CreateModel : CoffeeCategoriesPageModel
    {
        private readonly ECommerceShop.Data.ECommerceShopContext _context;

        public CreateModel(ECommerceShop.Data.ECommerceShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "ID", "CustomerName");

            var coffee = new Coffee();
            coffee.CoffeeCategories = new List<CoffeeCategory>();

            PopulateAssignedCategoryData(_context, coffee);

            return Page();
        }

        [BindProperty]
        public Coffee Coffee { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newCoffee = new Coffee();
            if (selectedCategories != null)
            {
                newCoffee.CoffeeCategories = new List<CoffeeCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CoffeeCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newCoffee.CoffeeCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Coffee>(
            newCoffee,
            "Coffee",
            i => i.Name, i => i.Feature, i => i.Price, i => i.ArrivingDate, i => i.CustomerID))
            {
                _context.Coffee.Add(newCoffee);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newCoffee);
            return Page();
        }

    }
}
