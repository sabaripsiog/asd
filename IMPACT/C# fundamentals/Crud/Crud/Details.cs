using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    class Details
    {
        public string customerID;
        public string email;
        public string address;
        public void getDetails()
        {
            Console.WriteLine("Enter customer ID:");
            customerID = Console.ReadLine();
            Console.WriteLine("Enter email:");
            email = Console.ReadLine();
            Console.WriteLine("Enter address:");
            address = Console.ReadLine();
        }
    }
}
