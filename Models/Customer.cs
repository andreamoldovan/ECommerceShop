using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceShop.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Display(Name = "Coffe Lover")]
        public string CustomerName { get; set; }

        [Display(Name = "Name")]
        public string LastName { get; set; }
        public ICollection<Coffee> Coffeee { get; set; }


    }
}
