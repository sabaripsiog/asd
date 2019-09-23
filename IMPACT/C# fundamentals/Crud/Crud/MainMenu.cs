using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    class MainMenu
    {
        public int userOption;
        public string Getoption;
        public bool Confirm = false;
        Menu m1 = new Menu();
        Admin admin1 = new Admin();
        
        public void Maindisplay(List<User> Usernames)
        {

            do
            {
                Console.WriteLine(" \t \t \t Welcome to TNEB Website!!");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1. User ");
                Console.WriteLine("2. Admin ");

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
                            m1.display1(Usernames);
                            break;

                        case 2:
                            Console.Clear();
                            admin1.CheckPass(Usernames);
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
        }
    }
}
