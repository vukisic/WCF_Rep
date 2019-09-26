using Server_App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WCFService service = new WCFService("AppService", typeof(UserAccountService)))
            {
                service.Open();


                Console.ReadLine();
            }
        }
    }
}
