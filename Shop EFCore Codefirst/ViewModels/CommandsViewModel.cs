using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_EFCore_Codefirst.ViewModels
{
    public class CommandsViewModel
    {
        public IEnumerable<Models.Command> Commands { get; set; }
        public IEnumerable<Models.Customer> Customers { get; set; }


        public Models.Command SingleCommand { get; set; }
        public Models.Customer SingleCustomer { get; set; }
    }
}
