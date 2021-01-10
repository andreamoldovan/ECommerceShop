using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceShop.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        public string Flavour { get; set; }

        [Required, StringLength(900, MinimumLength = 2)]
        [Display(Name = "Story")]
        public string Description { get; set; }
        public ICollection<CoffeeCategory> CoffeeCategories { get; set; }
    }
}
