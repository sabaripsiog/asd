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
        int userOption;
        string Getoption;
        bool Confirmval = false;
        public void getDetails()
        {
            do
            {
                Console.WriteLine("Enter customer ID:");
                customerID = Console.ReadLine();
                while (string.IsNullOrEmpty(customerID))
                {
                    Console.WriteLine("ID can't be empty! Input your Customer ID once more");
                    customerID = Console.ReadLine();
                }
                Console.WriteLine("Enter email:");
                email = Console.ReadLine();
                while (string.IsNullOrEmpty(email))
                {
                    Console.WriteLine("Email can't be empty! Input your email once more");
                    email = Console.ReadLine();
                }
                Console.WriteLine("Enter address:");
                address = Console.ReadLine();
                while (string.IsNullOrEmpty(address))
                {
                    Console.WriteLine("Address can't be empty! Input your address once more");
                    address = Console.ReadLine();
                }
                confirm();
            } while (Confirmval == true);
        }
        public void confirm()
        {
            Console.Clear();
            Console.WriteLine("Check whether the deatils are coorect");
            Console.WriteLine($"Customer ID : {customerID}");
            Console.WriteLine($"E-mail : {email}");
            Console.WriteLine($"Address : {address}");
            proceed();
        }

        public void proceed()
        {
            Console.WriteLine();
            Console.WriteLine("1.Continue");
            Console.WriteLine("2.Re-enter details");
            Console.WriteLine();
            Console.WriteLine("Enter your option");
            Getoption = Console.ReadLine();

            while (!int.TryParse(Getoption, out userOption))
            {
                Console.WriteLine("This is not a number!");
                Getoption = Console.ReadLine();
            }

            if ((userOption > 0) && (userOption < 3))
            {
                Confirmval = false;
                switch (userOption)
                {
                    case 1:
                        Console.Clear();
                        break;

                    case 2:
                        Console.Clear();
                        getDetails();
                        break;

                    default:
                        Console.WriteLine("No match found");
                        break;
                }
            }
            else
            {
                Confirmval = true;
                Console.Clear();
                Console.WriteLine("Re-enter the options");
            }
        }
    }
}
