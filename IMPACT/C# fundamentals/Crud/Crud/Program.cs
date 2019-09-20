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

            Usernames.Add(new User() { name = "sab", pass = "pass1", address = "8 , Raja street , Anna nagar.", customerID = 1 , customerType = "Domestic" , PreviousUnits = 600 , CurrentUnits = 680 });
            Usernames.Add(new User() { name = "xyz", pass = "pass2", address = "1 , Nehru street , T nagar.", customerID = 2, customerType = "Commercial", PreviousUnits = 2134, CurrentUnits = 2433 });
            Usernames.Add(new User() { name = "abc", pass = "pass3", address = "81 , MD street , Saidapet.", customerID = 3, customerType = "Domestic", PreviousUnits = 800, CurrentUnits = 931 });

            Menu m1 = new Menu();
            Login log = new Login();
            Details info = new Details();
            UserType u1 = new UserType();
            m1.display1(Usernames);
            log.Form(Usernames);
            //info.getDetails(Usernames);
            u1.select();
            Console.ReadKey();
        }
    }
}
