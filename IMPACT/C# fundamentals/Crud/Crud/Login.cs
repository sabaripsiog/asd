using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    class Login
    {
        bool isValue = true;
        public static string uname { get; set; }
        public string password { get; set; }
        public void Form(List<User> Usernames)
        {
            Console.WriteLine("\t\t\t Welcome To TNEB Website");
            Console.WriteLine();

            Console.WriteLine("Enter User Name");
            uname = Console.ReadLine();
            while (string.IsNullOrEmpty(uname))
            {
                Console.WriteLine("Name can't be empty! Input your Username once more");
                uname = Console.ReadLine();
            }

            Console.WriteLine();
            Console.WriteLine("Enter Password");
            password = Console.ReadLine();
            while (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Password can't be empty! Input your Password once more");
                password = Console.ReadLine();
            }

            Validate(Usernames);
        }

        public void Validate(List<User> Usernames)
        {

            foreach (User u in Usernames)
            {
                if (uname == u.name && password == u.pass)
                {
                    isValue = true;
                    break;
                }
                else
                {
                    isValue = false;
                }
            }
            if(isValue==true)
            {
                Console.Clear();
             
            }
            else
            {
                Console.Clear();
                Console.WriteLine("The UserName and Password is Wrong! Please try again");
                Form(Usernames);

            }
            GetDetails(Usernames);
        }

        public void GetDetails(List<User> Usernames)
        {
            Console.WriteLine("Check whether your details are correct");
            foreach (User u in Usernames)
            {
                if (uname == u.name && password == u.pass)
                {
                    Console.WriteLine($"Customer ID : {u.customerID}");
                    Console.WriteLine($"Address : {u.address}");
                    Console.WriteLine($"Type : {u.customerType}");
                }
            }
        }
    }
}
