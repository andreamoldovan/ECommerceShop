using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceShop.Models
{
    public class CoffeeCategory
    {
        public int ID { get; set; }
        public int CoffeeID { get; set; }
        public Coffee Coffee { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
