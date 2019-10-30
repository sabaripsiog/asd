using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    class NewUser
    {
        public string Username;
        public string Password;
        public string Address;
        public string CustomerType;
        public int CustomerId;

        public int GetCustomerID(List<User> Usernames)
        {
            CustomerId = Usernames[Usernames.Count - 1].CustomerId;
            CustomerId++;
            return CustomerId;
        }
        public string GetName()
        {
            Console.WriteLine("Enter New User name:");
            Username = Console.ReadLine();
            while (string.IsNullOrEmpty(Username))
            {
                Console.WriteLine("Name can't be empty! Input your Username once more");
                Username = Console.ReadLine();
            }
            return Username;
        }
        public string GetPass()
        {
            Console.WriteLine("Set Password:");
            Password = Console.ReadLine();
            while (string.IsNullOrEmpty(Password))
            {
                Console.WriteLine("Password can't be empty! Input your password once more");
                Password = Console.ReadLine();
            }
            return Password;
        }
        public string GetAddress()
        {
            Console.WriteLine("Enter the address:");
            Address = Console.ReadLine();
            while (string.IsNullOrEmpty(Address))
            {
                Console.WriteLine("Address can't be empty! Input your address once more");
                Address = Console.ReadLine();
            }
            return Address;
        }
        public string GetCustomerType()
        {
            Console.WriteLine("Enter Electricity type(Domestic(D) or Commercial(C):");
            CustomerType = Console.ReadLine();
            while (string.IsNullOrEmpty(CustomerType))
            {
                Console.WriteLine("Type can't be empty! Input your service type once more");
                CustomerType = Console.ReadLine();
            }
            while (CustomerType != "C" && CustomerType != "D" && CustomerType != "c" && CustomerType != "d")
            {
                Console.WriteLine("Type should either Domestic or Commercial");
                CustomerType = Console.ReadLine();
            }
            if (CustomerType == "C" || CustomerType == "c")
            {
                CustomerType = "Commercial";
            }
            else if (CustomerType == "D" || CustomerType == "d")
            {
                CustomerType = "Domestic";
            }
            return CustomerType;
        }
    }
}
