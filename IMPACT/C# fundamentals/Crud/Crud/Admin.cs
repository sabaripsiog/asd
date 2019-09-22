using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    class Admin
    {
        public string AdminPass = "admin";
        public string Allow;
        public int userOption;
        public string Getoption;
        public bool Confirm = false;
        public bool idNo = true;
        NewUser new2 = new NewUser();
        public string prev;
        public int prev1;
        public string current;
        public int current1;
        public void CheckPass(List<User> Usernames)
        {
            Console.WriteLine("Enter the admin pass.");
            Allow = Console.ReadLine();
            while (string.IsNullOrEmpty(Allow))
            {
                Console.WriteLine("Password can't be empty! Input password once more");
                Allow = Console.ReadLine(); 
            }
            while (Allow != AdminPass)
            {
                Console.WriteLine("Invalid password! Retry.");
                Allow = Console.ReadLine();
            }
            AdminOperation(Usernames);
        }

        public void AdminOperation(List<User> Usernames)
        {
            do
            {
                Console.WriteLine("Choose the operation to be done");
                Console.WriteLine();
                
                Console.WriteLine("1. Display consumer list ");
                Console.WriteLine("2. Update consumer details ");
                Console.WriteLine("3. Delete ");
                Console.WriteLine();
                Console.WriteLine("Enter your option");

                Getoption = Console.ReadLine();

                while (!int.TryParse(Getoption, out userOption))
                {
                    Console.WriteLine("This is not a number!");
                    Getoption = Console.ReadLine();
                }

                if ((userOption > 0) && (userOption < 4))
                {
                    Confirm = false;
                    switch (userOption)
                    {
                        case 1:
                            Console.Clear();
                            ListDisplay(Usernames);
                            break;

                        case 2:
                            Console.Clear();
                            UpdateList(Usernames);
                            break;

                        case 3:
                            Console.Clear();
                            DeleteOption(Usernames);
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

        public void DeleteOption(List<User> Usernames)
        {
            Console.WriteLine("Enter the ID of the customer to be deleted");
            Getoption = Console.ReadLine();

            while (!int.TryParse(Getoption, out userOption))
            {
                Console.WriteLine("This is not a number!");
                Getoption = Console.ReadLine();
            }
            if (userOption > 0 && userOption <= Usernames.Count)
            {
                Usernames.RemoveAll(idel => idel.customerID == userOption);
            }else
            {
                Console.WriteLine("Customer not found");
            }
            AdminOperation(Usernames);
        }

        public void UpdateList(List<User> Usernames)
        {
            do
            {
                Console.WriteLine("Choose which option to update");
                Console.WriteLine();

                Console.WriteLine("1. ConsumerType ");
                Console.WriteLine("2. Previous Units and Current Units");

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
                            UpdateType(Usernames);
                            break;

                        case 2:
                            Console.Clear();
                            UpdateUnits(Usernames);
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

        public void UpdateUnits(List<User> Usernames)
        {
            Console.WriteLine("Enter the customer ID for which units has to be updated");
            Getoption = Console.ReadLine();

            while (!int.TryParse(Getoption, out userOption))
            {
                Console.WriteLine("This is not a number!");
                Getoption = Console.ReadLine();
            }
            if (userOption > 0 && userOption <= Usernames.Count)
            {
                foreach (User u in Usernames)
                {
                    if (userOption == u.customerID)
                    {
                        Console.WriteLine("Enter Previous units:");
                        prev = Console.ReadLine();
                        while (!int.TryParse(prev, out prev1))
                        {
                            Console.WriteLine("This is not a number!");
                            prev = Console.ReadLine();
                        }
                        u.PreviousUnits = prev1;
                        Console.WriteLine("Enter Current units:");
                        current = Console.ReadLine();
                        while (!int.TryParse(current, out current1))
                        {
                            Console.WriteLine("This is not a number!");
                            current = Console.ReadLine();
                        }
                        u.CurrentUnits = current1;
                        while (u.CurrentUnits <= u.PreviousUnits)
                        {
                            Console.WriteLine("Current Units should be greater than Previous units.");
                            current = Console.ReadLine();
                            u.CurrentUnits = int.Parse(current);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Customer not found");
            }
            AdminOperation(Usernames);
        }

        public void UpdateType(List<User> Usernames)
        {
            Console.WriteLine("Enter the customer ID for which type has to be updated");
            Getoption = Console.ReadLine();

            while (!int.TryParse(Getoption, out userOption))
            {
                Console.WriteLine("This is not a number!");
                Getoption = Console.ReadLine();
            }
            if (userOption > 0 && userOption <= Usernames.Count)
            {
                foreach (User u in Usernames)
                {
                    if (userOption == u.customerID)
                    {
                        u.customerType = new2.getType();
                      
                    }
                }
            }else
            {
                Console.WriteLine("Customer not found");
            }
            AdminOperation(Usernames);
        }

        public void ListDisplay(List<User> Usernames)
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("ID\tName\tType\tPrev Units\tCurr Units");
            Console.WriteLine("-------------------------------------------------------------------");
            foreach (User u in Usernames)
            {
                Console.WriteLine($"{u.customerID}\t{u.name}\t{u.customerType}\t{u.PreviousUnits}\t{u.CurrentUnits}");
            }
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            AdminOperation(Usernames);
        }
    }
}
