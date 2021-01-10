using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceShop.Models
{
    public class CoffeeData
    {
        public IEnumerable<Coffee> Coffeee   { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<CoffeeCategory> CoffeeCategories { get; set; }

    }
}
