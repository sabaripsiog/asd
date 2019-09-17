using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    class NewUser
    {
        public string username;
        public string pass;
        public string getName()
        {
            Console.WriteLine("Enter New User name:");
            username = Console.ReadLine();
            return username;
        }
        public string getPass()
        {
            Console.WriteLine("Enter New Password:");
            pass = Console.ReadLine();
            return pass;
        }
    }
}
