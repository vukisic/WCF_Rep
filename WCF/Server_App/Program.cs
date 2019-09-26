using Server_App.Services;
using System;

namespace Server_App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (WCFService service = new WCFService("AppService", typeof(UserAccountService)))
            {
                service.Open();

                Console.ReadLine();
            }
        }
    }
}