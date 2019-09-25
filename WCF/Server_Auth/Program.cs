using Common.Cryptography;
using Server_Auth.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Server_Auth
{
    class Program
    {
        static void Main(string[] args)
        {
            using(WCFService service = new WCFService("AuthService", typeof(UserAuthService)))
            {
                service.Open();


                Console.ReadLine();
            }
            
        }
    }
}
