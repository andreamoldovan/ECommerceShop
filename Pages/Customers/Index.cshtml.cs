using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ECommerceShop.Data;
using ECommerceShop.Models;

namespace ECommerceShop.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ECommerceShop.Data.ECommerceShopContext _context;

        public IndexModel(ECommerceShop.Data.ECommerceShopContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customer.ToListAsync();
        }
    }
}
