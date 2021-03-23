using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_EFCore_Codefirst.Models
{
    public class Command
    {
        public Guid Id { get; set; }
        public DateTime ValidationDate { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<CommandProduct> CommandProducts { get; set; }
    }
}
