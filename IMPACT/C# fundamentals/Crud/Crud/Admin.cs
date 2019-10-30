using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    class Admin
    {
        public int UserOption;
        public string GetOption;
        public bool Confirm = false;
        public bool IdNo = true;
        NewUser New2 = new NewUser();
        public string Prev;
        public int Prev1;
        public string Current;
        public int Current1;
        public string Username;
        public string Password;
        public string UserAddress;
        public string Type;
        public int ID;
        NewUser new1 = new NewUser();
        
        Bill item = new Bill();
        public void CheckPass(List<User> Usernames)
        {
            Console.WriteLine(" \t \t \t Welcome to TNEB Website!!");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Welcome admin");
            Console.WriteLine();

            AdminOperation(Usernames);
        }

        public void AdminOperation(List<User> Usernames)
        {
            do
            {
                Console.WriteLine("Choose the operation to be done");
                Console.WriteLine();
                
                Console.WriteLine("1. Display consumer list ");
                Console.WriteLine("2. Register a new user ");
                Console.WriteLine("3. Update consumer details ");
                Console.WriteLine("4. Print consumer bill ");
                Console.WriteLine("5. Delete an entry ");
                Console.WriteLine("6. Exit ");
                Console.WriteLine();
                Console.WriteLine("Enter your option");

                GetOption = Console.ReadLine();

                while (!int.TryParse(GetOption, out UserOption))
                {
                    Console.WriteLine("This is not a number!");
                    GetOption = Console.ReadLine();
                }

                if ((UserOption > 0) && (UserOption < 7))
                {
                    Confirm = false;
                    switch (UserOption)
                    {
                        case 1:
                            Console.Clear();
                            ListDisplay(Usernames);
                            AdminOperation(Usernames);
                            break;

                        case 2:
                            Console.Clear();
                            Username = new1.GetName();
                            Password = new1.GetPass();
                            UserAddress = new1.GetAddress();
                            Type = new1.GetCustomerType();
                            ID = new1.GetCustomerID(Usernames);
                            Usernames.Add(new User() { Name = Username, Password = Password, Address = UserAddress, CustomerType = Type, CustomerId = ID, CurrentUnits = 100, PreviousUnits = 0 });
                            Console.Clear();
                            Console.WriteLine("Registered Successfully");
                            ListDisplay(Usernames);
                            AdminOperation(Usernames);
                            break;

                        case 3:
                            Console.Clear();
                            UpdateList(Usernames);
                           
                            AdminOperation(Usernames);
                            break;

                        case 4:
                            Console.Clear();
                            ListDisplay(Usernames);
                            item.BillIt(Usernames);
                            
                            AdminOperation(Usernames);
                            
                            break;

                        case 5:
                            Console.Clear();
                            DeleteOption(Usernames);
                            
                            AdminOperation(Usernames);
                            break;

                        case 6:
                            Console.WriteLine("Press any key to exit");
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
            ListDisplay(Usernames);
            Console.WriteLine("Enter the ID of the customer to be deleted");
            GetOption = Console.ReadLine();

            while (!int.TryParse(GetOption, out UserOption))
            {
                Console.WriteLine("This is not a number!");
                GetOption = Console.ReadLine();
            }
            if (UserOption > 0 && UserOption <= Usernames.Count)
            {
                Usernames.RemoveAll(idel => idel.CustomerId == UserOption);

                ListDisplay(Usernames);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Customer not found");
            }
            
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

                GetOption = Console.ReadLine();

                while (!int.TryParse(GetOption, out UserOption))
                {
                    Console.WriteLine("This is not a number!");
                    GetOption = Console.ReadLine();
                }

                if ((UserOption > 0) && (UserOption < 3))
                {
                    Confirm = false;
                    switch (UserOption)
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
            ListDisplay(Usernames);
            Console.WriteLine("Enter the customer ID for which units has to be updated");
            GetOption = Console.ReadLine();

            while (!int.TryParse(GetOption, out UserOption))
            {
                Console.WriteLine("This is not a number!");
                GetOption = Console.ReadLine();
            }
            if (UserOption > 0 && UserOption <= Usernames.Count)
            {
                foreach (User user in Usernames)
                {
                    if (UserOption == user.CustomerId)
                    {
                        Console.WriteLine("Enter Previous units:");
                        Prev = Console.ReadLine();
                        while (!int.TryParse(Prev, out Prev1))
                        {
                            Console.WriteLine("This is not a number!");
                            Prev = Console.ReadLine();
                        }
                        user.PreviousUnits = Prev1;
                        Console.WriteLine("Enter Current units:");
                        Current = Console.ReadLine();
                        while (!int.TryParse(Current, out Current1))
                        {
                            Console.WriteLine("This is not a number!");
                            Current = Console.ReadLine();
                        }
                        user.CurrentUnits = Current1;
                        while (user.CurrentUnits <= user.PreviousUnits)
                        {
                            Console.WriteLine("Current Units should be greater than Previous units.");
                            Current = Console.ReadLine();
                            user.CurrentUnits = int.Parse(Current);
                        }
                        ListDisplay(Usernames);
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Customer not found");
            }
            
        }

        public void UpdateType(List<User> Usernames)
        {
            ListDisplay(Usernames);
            Console.WriteLine("Enter the customer ID for which type has to be updated");
            GetOption = Console.ReadLine();

            while (!int.TryParse(GetOption, out UserOption))
            {
                Console.WriteLine("This is not a number!");
                GetOption = Console.ReadLine();
            }
            if (UserOption > 0 && UserOption <= Usernames.Count)
            {
                foreach (User user in Usernames)
                {
                    if (UserOption == user.CustomerId)
                    {
                        user.CustomerType = New2.GetCustomerType();
                        ListDisplay(Usernames);
                    }
                }
            }else
            {
                Console.Clear();
                Console.WriteLine("Customer not found");
            }
            
        }

        public void ListDisplay(List<User> Usernames)
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("ID\tName\tType\tPrev Units\tCurr Units");
            Console.WriteLine("-------------------------------------------------------------------");
            foreach (User user in Usernames)
            {
                Console.WriteLine($"{user.CustomerId}\t{user.Name}\t{user.CustomerType}\t{user.PreviousUnits}\t{user.CurrentUnits}");
            }
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            
        }
    }
}
