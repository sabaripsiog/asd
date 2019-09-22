using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    class Bill 
    {
        
        public int Units_this_month;

        public double Rupees_per_unit;

        public double Total;
        public void BillIt(User u)
        {
            
            Console.WriteLine();
            Console.WriteLine("Press Enter to proceed to bill.");
            Console.ReadLine();
            Console.Clear();
            
            
            PrintDetails(u);
            doCalculation(u);
        }
        public void PrintDetails(User u)
        {
            Console.WriteLine("---------------------------TNEB------------------------------");
            Console.WriteLine("---------------------------BILL------------------------------");
            Console.WriteLine("Date:"+DateTime.Now.ToString("dd/MM/yyyy")+ "\t\t\t\t\t"+"Time:"+ DateTime.Now.ToString("hh:mm tt"));
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine($"Consumer name:{u.name}\t\t\t\tConsumer ID:{u.customerID}");
            Console.WriteLine($"Consumer Address:{u.address}");
        }

        public void doCalculation(User u)
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

            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine($"Current consumption: \t\t\t\t {Units_this_month}");
            Console.WriteLine($"Per unit charge: \t\t\t\t {Rupees_per_unit}");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine($"Total charges: \t\t\t\t\t {Total}");
            Console.WriteLine("-------------------------------------------------------------------");
        }
    }
}
