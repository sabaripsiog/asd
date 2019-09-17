using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> Usernames = new List<User>();                                             //List for users

            Usernames.Add(new User() { name = "Sab", pass = "pass1" });
            Usernames.Add(new User() { name = "xyz", pass = "pass2" });
            Usernames.Add(new User() { name = "abc", pass = "pass3" });
            int userOption;
            string Getoption;
            string uname;
            string passw;
            NewUser new1 = new NewUser();
            bool Confirm = false;
            Login log = new Login();
            Details info = new Details();
            do
            {
                Console.WriteLine(" \t \t \t Welcome to TNEB Website!!");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1. Existing User ");
                Console.WriteLine("2. New User ");
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
                    Confirm = false;
                    switch (userOption)
                    {
                        case 1:
                            Console.Clear();
                            log.Form(Usernames);
                            break;

                        case 2:
                            Console.Clear();
                            uname = new1.getName();
                            passw = new1.getPass();
                            Usernames.Add(new User() { name = uname, pass = passw });
                            Console.Clear();
                            Console.WriteLine("Registered Successfully");
                            log.Form(Usernames);
                            break;

                        default:
                            Console.WriteLine("No match found");
                            break;
                    }
                }
                else
                {
                    Confirm = true;
                    Console.Clear();
                    Console.WriteLine("Re-enter the options");
                }

            } while (Confirm == true);

            info.getDetails();

            Console.ReadKey();
        }
    }
}
