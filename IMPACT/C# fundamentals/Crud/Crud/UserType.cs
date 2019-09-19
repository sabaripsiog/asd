using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    class UserType : Menu
    {
        public void select()
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine("1.Commercial");
                Console.WriteLine("2.Domestic");
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
                            showCommercial();
                            break;

                        case 2:
                            Console.Clear();
                            showDomestic();
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
        public void showCommercial()
        {
            Console.WriteLine("Units at the end of previous month:");

        }
        public void showDomestic()
        {

        }
    }
}
