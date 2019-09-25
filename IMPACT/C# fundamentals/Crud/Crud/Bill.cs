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
        public int userOption;
        public string Getoption;
        public bool Confirm = false;
        public Bill2 X;
        public int Units_this_month;

        public double Rupees_per_unit;

        public double Total;
        public List<Bill2> BillList = new List<Bill2>();
        public void BillIt(User u)
        {
            
            Console.WriteLine();
            Console.WriteLine("Press Enter to proceed to bill.");
            Console.ReadLine();
            Console.Clear();

            
            PrintDetails(u);
           
        }
        public void PrintDetails(User u)
        {
            Units_this_month = u.CurrentUnits - u.PreviousUnits;
            if (u.customerType == "Domestic")
            {
                if (Units_this_month <= 100)
                {
                    Rupees_per_unit = 1.5;
                }
                else if (Units_this_month > 100 && Units_this_month <= 300)
                {
                    Rupees_per_unit = 3.5;
                }
                else if (Units_this_month > 300)
                {
                    Rupees_per_unit = 6;
                }
            }
            else if (u.customerType == "Commercial")
            {
                if (Units_this_month <= 200)
                {
                    Rupees_per_unit = 2;
                }
                else if (Units_this_month > 200 && Units_this_month <= 500)
                {
                    Rupees_per_unit = 5.5;
                }
                else if (Units_this_month > 500)
                {
                    Rupees_per_unit = 10.3;
                }
            }
            Total = Rupees_per_unit * Units_this_month;




            Console.WriteLine("---------------------------TNEB------------------------------");
            Console.WriteLine("---------------------------BILL------------------------------");
            Console.WriteLine("Date:" + DateTime.Now.ToString("dd/MM/yyyy") + "\t\t\t\t\t" + "Time:" + DateTime.Now.ToString("hh:mm tt"));
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine($"Consumer name:{u.name}\t\t\t\tConsumer ID:{u.customerID}");
            Console.WriteLine($"Consumer Address:{u.address}");


            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine($"Current consumption: \t\t\t\t {Units_this_month}");
            Console.WriteLine($"Per unit charge: \t\t\t\t {Rupees_per_unit}");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine($"Total charges: \t\t\t\t\t {Total}");
            Console.WriteLine("-------------------------------------------------------------------");


            StreamWriter billfile = new StreamWriter(@"Bill.txt");

            billfile.WriteLine("---------------------------TNEB------------------------------");
            billfile.WriteLine("---------------------------BILL------------------------------");
            billfile.WriteLine("Date:" + DateTime.Now.ToString("dd/MM/yyyy") + "\t\t\t\t\t" + "Time:" + DateTime.Now.ToString("hh:mm tt"));
            billfile.WriteLine("-------------------------------------------------------------------");
            billfile.WriteLine($"Consumer name:{u.name}\t\t\t\tConsumer ID:{u.customerID}");
            billfile.WriteLine($"Consumer Address:{u.address}");
            

            billfile.WriteLine("-------------------------------------------------------------------");
            billfile.WriteLine($"Current consumption: \t\t\t\t {Units_this_month}");
            billfile.WriteLine($"Per unit charge: \t\t\t\t {Rupees_per_unit}");
            billfile.WriteLine("-------------------------------------------------------------------");
            billfile.WriteLine($"Total charges: \t\t\t\t\t {Total}");
            billfile.WriteLine("-------------------------------------------------------------------");
            billfile.Close();
            Console.WriteLine();
            Console.WriteLine();
            
            BillList.Add(new Bill2() { unitPerMonth = Units_this_month, RupeesPerUnit = Rupees_per_unit, Total = Total });
            foreach(Bill2 b in BillList)
            {
                X = b;
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
                            SaveAsXml(u, X);
                            break;

                        case 2:
                            SaveAsJson(u, X);
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
            Console.WriteLine("Your Bill has been printed. Please press enter to exit");
            
        }
        public void SaveAsJson(User u, Bill2 X)
        {
            using (StreamWriter file = File.CreateText(@"Billjson.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, u);
                serializer.Serialize(file, X);
            }
            using (StreamReader r = new StreamReader(@"Billjson.json"))
            {
                string json = r.ReadToEnd();
                JsonConvert.SerializeObject(json, Formatting.Indented);
            }
        }
        public void SaveAsXml(User u, Bill2 X)
        {
            XmlSerializer xs = new XmlSerializer(typeof(User));
            XmlSerializer xs1 = new XmlSerializer(typeof(Bill2));
            TextWriter txtWriter = new StreamWriter(@"Billxml.xml");

            xs.Serialize(txtWriter, u);
            xs1.Serialize(txtWriter, X);
            txtWriter.Close();
        }
    }
}
