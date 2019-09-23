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
            Usernames.Add(new User() { name = "abc", pass = "pass3", address = "56 , MD street , Saidapet.", customerID = 3, customerType = "Domestic", PreviousUnits = 800, CurrentUnits = 931 });
            Usernames.Add(new User() { name = "adi", pass = "pass4", address = "813 , HM street , Mylapore.", customerID = 4, customerType = "Commercial", PreviousUnits = 1800, CurrentUnits = 2400 });
            Usernames.Add(new User() { name = "sri", pass = "pass5", address = "82, Circle street , Koyembedu.", customerID = 5, customerType = "Commercial", PreviousUnits = 549, CurrentUnits = 789 });
            Usernames.Add(new User() { name = "sam", pass = "pass6", address = "22 , Ananda street , Egmore.", customerID = 6, customerType = "Domestic", PreviousUnits = 4555, CurrentUnits = 4999 });
            Usernames.Add(new User() { name = "joe", pass = "pass7", address = "36 , Usha street , Kodambakkam.", customerID = 7, customerType = "Commercial", PreviousUnits = 3333, CurrentUnits = 3906 });
            Usernames.Add(new User() { name = "pop", pass = "pass8", address = "88 , Mohan street , Vadapalani.", customerID = 8, customerType = "Domestic", PreviousUnits = 1223, CurrentUnits = 1590 });
            Usernames.Add(new User() { name = "sen", pass = "pass9", address = "44 , Dino street , Perungudi.", customerID = 9, customerType = "Domestic", PreviousUnits = 567, CurrentUnits = 931 });
            Usernames.Add(new User() { name = "abu", pass = "pass0", address = "24 , KD street , Alwarpet.", customerID = 10, customerType = "Commercial", PreviousUnits = 2333, CurrentUnits = 3976 });

            MainMenu main1 = new MainMenu();
            main1.Maindisplay(Usernames);
            
            
            Console.ReadKey();
          
        }
    }
}
