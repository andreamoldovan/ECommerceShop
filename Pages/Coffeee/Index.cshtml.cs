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
    public class IndexModel : PageModel
    {
        private readonly ECommerceShop.Data.ECommerceShopContext _context;

        public IndexModel(ECommerceShop.Data.ECommerceShopContext context)
        {
            _context = context;
        }

        public IList<Coffee> Coffee { get;set; }
        public CoffeeData CoffeeD { get; set; }
        public int CoffeeID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            CoffeeD = new CoffeeData();

            CoffeeD.Coffeee = await _context.Coffee
            .Include(b => b.Customer)
            .Include(b => b.CoffeeCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                CoffeeID = id.Value;
                Coffee coffee = CoffeeD.Coffeee
                .Where(i => i.ID == id.Value).Single();
                CoffeeD.Categories = coffee.CoffeeCategories.Select(s => s.Category);
            }
        }

    }
}
