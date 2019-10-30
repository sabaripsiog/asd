using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    class Bill 
    {
        public int UserOption;
        public string GetOption;
        public bool Confirm = false;
        public BillAddOn BillDetails;
        public int UnitsThisMonth;
        
        public double RupeesPerUnit;

        public double Total;
        public List<BillAddOn> BillList = new List<BillAddOn>();
        public void BillIt(List<User> Usernames)
        {
            
            Console.WriteLine("Enter the ID of the customer to print bill");
            GetOption = Console.ReadLine();

            while (!int.TryParse(GetOption, out UserOption))
            {
                Console.WriteLine("This is not a number!");
                GetOption = Console.ReadLine();
            }

            if ((UserOption > 0) && (UserOption <= Usernames.Count))
            {
                foreach (User user in Usernames)
                {
                    if (user.CustomerId == UserOption)
                    {
                        PrintDetails(user);
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Customer not found");
            }
            
        }
        public void PrintDetails(User u)
        {
            UnitsThisMonth = u.CurrentUnits - u.PreviousUnits;
            if (u.CustomerType == "Domestic")
            {
                if (UnitsThisMonth <= 100)
                {
                    RupeesPerUnit = 1.5;
                }
                else if (UnitsThisMonth > 100 && UnitsThisMonth <= 300)
                {
                    RupeesPerUnit = 3.5;
                }
                else if (UnitsThisMonth > 300)
                {
                    RupeesPerUnit = 6;
                }
            }
            else if (u.CustomerType == "Commercial")
            {
                if (UnitsThisMonth <= 200)
                {
                    RupeesPerUnit = 2;
                }
                else if (UnitsThisMonth > 200 && UnitsThisMonth <= 500)
                {
                    RupeesPerUnit = 5.5;
                }
                else if (UnitsThisMonth > 500)
                {
                    RupeesPerUnit = 10.3;
                }
            }
            Total = RupeesPerUnit * UnitsThisMonth;


            Console.Clear();

            Console.WriteLine("---------------------------TNEB------------------------------");
            Console.WriteLine("---------------------------BILL------------------------------");
            Console.WriteLine("Date:" + DateTime.Now.ToString("dd/MM/yyyy") + "\t\t\t\t\t" + "Time:" + DateTime.Now.ToString("hh:mm tt"));
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine($"Consumer name:{u.Name}\t\t\t\tConsumer ID:{u.CustomerId}");
            Console.WriteLine($"Consumer Address:{u.Address}");


            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine($"Current consumption: \t\t\t\t {UnitsThisMonth}");
            Console.WriteLine($"Per unit charge: \t\t\t\t {RupeesPerUnit}");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine($"Total charges: \t\t\t\t\t {Total}");
            Console.WriteLine("-------------------------------------------------------------------");


            StreamWriter billfile = new StreamWriter(@"Bill.txt");

            billfile.WriteLine("---------------------------TNEB------------------------------");
            billfile.WriteLine("---------------------------BILL------------------------------");
            billfile.WriteLine("Date:" + DateTime.Now.ToString("dd/MM/yyyy") + "\t\t\t\t\t" + "Time:" + DateTime.Now.ToString("hh:mm tt"));
            billfile.WriteLine("-------------------------------------------------------------------");
            billfile.WriteLine($"Consumer name:{u.Name}\t\t\t\tConsumer ID:{u.CustomerId}");
            billfile.WriteLine($"Consumer Address:{u.Address}");
            

            billfile.WriteLine("-------------------------------------------------------------------");
            billfile.WriteLine($"Current consumption: \t\t\t\t {UnitsThisMonth}");
            billfile.WriteLine($"Per unit charge: \t\t\t\t {RupeesPerUnit}");
            billfile.WriteLine("-------------------------------------------------------------------");
            billfile.WriteLine($"Total charges: \t\t\t\t\t {Total}");
            billfile.WriteLine("-------------------------------------------------------------------");
            billfile.Close();
            Console.WriteLine();
            Console.WriteLine();
            
            BillList.Add(new BillAddOn() { UnitPerMonth = UnitsThisMonth, RupeesPerUnit = RupeesPerUnit, Total = Total });
            foreach(BillAddOn AddOn in BillList)
            {
                BillDetails = AddOn;
            }
            File.Delete(@"Billjson.json");
            File.Delete(@"Billxml.xml");
            do
            {
                Console.WriteLine(" Enter the format for your bill");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1. XML ");
                Console.WriteLine("2. Json ");

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
                            SaveAsXml(u, BillDetails);
                            break;

                        case 2:
                            SaveAsJson(u, BillDetails);
                            break;

                        default:
                            Console.WriteLine("No match found");
                            break;
                    }
                }
                else
                {
                    Confirm = true;
                    Console.WriteLine("Re-enter the options");
                }

            } while (Confirm == true);
            Console.WriteLine("Your Bill has been printed. Please press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
        public void SaveAsJson(User user, BillAddOn AddOn)
        {
            using (StreamWriter file = File.CreateText(@"Billjson.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, user);
                serializer.Serialize(file, AddOn);
            }
            using (StreamReader r = new StreamReader(@"Billjson.json"))
            {
                string json = r.ReadToEnd();
                JsonConvert.SerializeObject(json, Formatting.Indented);
            }
        }
        public void SaveAsXml(User user, BillAddOn AddOn)
        {
            XmlSerializer xs = new XmlSerializer(typeof(User));
            XmlSerializer xs1 = new XmlSerializer(typeof(BillAddOn));
            TextWriter txtWriter = new StreamWriter(@"Billxml.xml");

            xs.Serialize(txtWriter, user);
            xs1.Serialize(txtWriter, AddOn);
            txtWriter.Close();
        }
    }
}
