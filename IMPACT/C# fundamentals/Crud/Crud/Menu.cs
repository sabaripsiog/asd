﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    class Menu
    {
        public int userOption;
        public string Getoption;
        public bool Confirm = false;
        public string uname;
        public string passw;
        public string useraddress;
        public string type;
        public int count = 10;
        NewUser new1 = new NewUser();
        Admin admin1 = new Admin();
        public void display1(List<User> Usernames)
        {
            do
            {
                Console.WriteLine(" \t \t \t Welcome to TNEB Website!!");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1. Existing User ");
                Console.WriteLine("2. New User ");
                Console.WriteLine("3. Admin ");
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
                            break;

                        case 2:
                            Console.Clear();
                            uname = new1.getName();
                            passw = new1.getPass();
                            useraddress = new1.getAddress();
                            type = new1.getType();
                            Usernames.Add(new User() { name = uname, pass = passw , address = useraddress, customerType = type, customerID = count+1 , CurrentUnits = 0, PreviousUnits = 0});
                            Console.Clear();
                            Console.WriteLine("Registered Successfully");
                            break;

                        case 3:
                            Console.Clear();
                            admin1.CheckPass(Usernames);
                            Confirm = true;
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
