using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ECommerceShop.Data;
using ECommerceShop.Models;

namespace ECommerceShop.Pages.Coffeee
{
    public class DetailsModel : PageModel
    {
        private readonly ECommerceShop.Data.ECommerceShopContext _context;

        public DetailsModel(ECommerceShop.Data.ECommerceShopContext context)
        {
            _context = context;
        }

        public Coffee Coffee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Coffee = await _context.Coffee.FirstOrDefaultAsync(m => m.ID == id);

            if (Coffee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
