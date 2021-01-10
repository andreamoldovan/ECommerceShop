using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ECommerceShop.Data;
using ECommerceShop.Models;

namespace ECommerceShop.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly ECommerceShop.Data.ECommerceShopContext _context;

        public DetailsModel(ECommerceShop.Data.ECommerceShopContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
