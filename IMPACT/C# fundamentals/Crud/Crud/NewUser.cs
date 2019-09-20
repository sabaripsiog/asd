using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    class NewUser
    {
        public string username;
        public string pass;
        public string address;
        public string customerType;
        
        
        public string getName()
        {
            Console.WriteLine("Enter New User name:");
            username = Console.ReadLine();
            while (string.IsNullOrEmpty(username))
            {
                Console.WriteLine("Name can't be empty! Input your Username once more");
                username = Console.ReadLine();
            }
            return username;
        }
        public string getPass()
        {
            Console.WriteLine("Enter New Password:");
            pass = Console.ReadLine();
            while (string.IsNullOrEmpty(pass))
            {
                Console.WriteLine("Password can't be empty! Input your password once more");
                pass = Console.ReadLine();
            }
            return pass;
        }
        public string getAddress()
        {
            Console.WriteLine("Enter your address:");
            address = Console.ReadLine();
            while (string.IsNullOrEmpty(address))
            {
                Console.WriteLine("Address can't be empty! Input your address once more");
                address = Console.ReadLine();
            }
            return address;
        }
        public string getType()
        {
            Console.WriteLine("Enter Electricity type(Domestic(D) or Commercial(C):");
            customerType = Console.ReadLine();
            while (string.IsNullOrEmpty(customerType))
            {
                Console.WriteLine("Password can't be empty! Input your password once more");
                customerType = Console.ReadLine();
            }
            while (customerType != "C" && customerType != "D" && customerType != "c" && customerType != "d")
            {
                Console.WriteLine("Type should either Commercial or Domestic");
                customerType = Console.ReadLine();
            }
            return customerType;
        }
    }
}
