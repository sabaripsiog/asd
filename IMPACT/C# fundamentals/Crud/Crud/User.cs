using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    class User
    {
        public string name { get; set; }
        public string pass { get; set; } 
        public int customerID { get; set; }
        public string address { get; set; }
        public string customerType { get; set; }
        public int PreviousUnits { get; set; }
        public int CurrentUnits { get; set; }

    }
}
