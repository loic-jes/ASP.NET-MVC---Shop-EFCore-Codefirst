using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_EFCore_Codefirst.Models
{
    public class CommandProduct
    {
        public Guid CommandId { get; set; }
        public Command Command { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
