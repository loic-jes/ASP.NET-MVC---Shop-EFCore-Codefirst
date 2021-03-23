using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_EFCore_Codefirst.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [Display(Name = "Titre")]
        public string Title { get; set; }

        [Display(Name = "Prix")]

        public double Price { get; set; }

        public virtual ICollection<CommandProduct> CommandProducts { get; set; }
    }
}
