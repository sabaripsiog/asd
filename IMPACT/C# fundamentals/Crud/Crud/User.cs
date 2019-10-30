using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; } 
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public string CustomerType { get; set; }
        public int PreviousUnits { get; set; }
        public int CurrentUnits { get; set; }

    }
}
