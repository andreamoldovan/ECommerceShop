using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ECommerceShop.Models;

namespace ECommerceShop.Data
{
    public class ECommerceShopContext : DbContext
    {
        public ECommerceShopContext (DbContextOptions<ECommerceShopContext> options)
            : base(options)
        {
        }

        public DbSet<ECommerceShop.Models.Coffee> Coffee { get; set; }

        public DbSet<ECommerceShop.Models.Customer> Customer { get; set; }

        public DbSet<ECommerceShop.Models.Category> Category { get; set; }


    }
}
