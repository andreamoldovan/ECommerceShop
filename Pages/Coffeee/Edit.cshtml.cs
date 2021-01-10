using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerceShop.Data;
using ECommerceShop.Models;

namespace ECommerceShop.Pages.Coffeee
{
    public class EditModel : CoffeeCategoriesPageModel
    {
        private readonly ECommerceShop.Data.ECommerceShopContext _context;

        public EditModel(ECommerceShop.Data.ECommerceShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Coffee Coffee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Coffee = await _context.Coffee.Include(b => b.Customer).Include(b => b.CoffeeCategories).ThenInclude(b => b.Category).AsNoTracking()
 .FirstOrDefaultAsync(m => m.ID == id);

            if (Coffee == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Coffee);

            ViewData["CustomerID"] = new SelectList(_context.Customer, "ID","CustomerName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
 {
            {
                if (id == null)
                {
                    return NotFound();
                }
                var coffeeToUpdate = await _context.Coffee
                .Include(i => i.Customer)
                .Include(i => i.CoffeeCategories)
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);
                if (coffeeToUpdate == null)
                {
                    return NotFound();
                }
                if (await TryUpdateModelAsync<Coffee>(coffeeToUpdate,"Coffee", i => i.Name, i => i.Feature,
 i => i.Price, i => i.ArrivingDate, i => i.Customer))
                {
                    UpdateCoffeeCategories(_context, selectedCategories, coffeeToUpdate);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                UpdateCoffeeCategories(_context, selectedCategories, coffeeToUpdate);
                PopulateAssignedCategoryData(_context, coffeeToUpdate);
                return Page();
            }
        }
    }

}
