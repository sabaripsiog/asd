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
            int Count = 1;
            Usernames.Add(new User() { Name = "sab", Password = "pass1", Address = "8 , Raja street , Anna nagar.", CustomerId = Count++ , CustomerType = "Domestic" , PreviousUnits = 600 , CurrentUnits = 680 });
            Usernames.Add(new User() { Name = "xyz", Password = "pass2", Address = "1 , Nehru street , T nagar.", CustomerId = Count++, CustomerType = "Commercial", PreviousUnits = 2134, CurrentUnits = 2433 });
            Usernames.Add(new User() { Name = "abc", Password = "pass3", Address = "56 , MD street , Saidapet.", CustomerId = Count++, CustomerType = "Domestic", PreviousUnits = 800, CurrentUnits = 931 });
            Usernames.Add(new User() { Name = "adi", Password = "pass4", Address = "813 , HM street , Mylapore.", CustomerId = Count++, CustomerType = "Commercial", PreviousUnits = 1800, CurrentUnits = 2400 });
            Usernames.Add(new User() { Name = "sri", Password = "pass5", Address = "82, Circle street , Koyembedu.", CustomerId = Count++, CustomerType = "Commercial", PreviousUnits = 549, CurrentUnits = 789 });
            Usernames.Add(new User() { Name = "sam", Password = "pass6", Address = "22 , Ananda street , Egmore.", CustomerId = Count++, CustomerType = "Domestic", PreviousUnits = 4555, CurrentUnits = 4999 });
            Usernames.Add(new User() { Name = "joe", Password = "pass7", Address = "36 , Usha street , Kodambakkam.", CustomerId = Count++, CustomerType = "Commercial", PreviousUnits = 3333, CurrentUnits = 3906 });
            Usernames.Add(new User() { Name = "pop", Password = "pass8", Address = "88 , Mohan street , Vadapalani.", CustomerId = Count++, CustomerType = "Domestic", PreviousUnits = 1223, CurrentUnits = 1590 });
            Usernames.Add(new User() { Name = "sen", Password = "pass9", Address = "44 , Dino street , Perungudi.", CustomerId = Count++, CustomerType = "Domestic", PreviousUnits = 567, CurrentUnits = 931 });
            Usernames.Add(new User() { Name = "abu", Password = "pass0", Address = "24 , KD street , Alwarpet.", CustomerId = Count++, CustomerType = "Commercial", PreviousUnits = 2333, CurrentUnits = 3976 });

            Admin admin1 = new Admin();
            admin1.CheckPass(Usernames);

            Console.ReadKey();
          
        }
    }
}
