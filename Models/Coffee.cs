using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceShop.Models
{
    public class Coffee
    {
        public int ID { get; set; }

        [Required, StringLength(200, MinimumLength = 5)]
        [Display(Name = "Coffee Name")]
        public string Name { get; set; }
        public string Feature { get; set; }

        [Range(1, 500)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime ArrivingDate { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [Display(Name = "Produced by")]
        public ICollection<CoffeeCategory> CoffeeCategories { get; set; }

    }
}
