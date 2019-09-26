using Server_Auth.Services;
using System;

namespace Server_Auth
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (WCFService service = new WCFService("AuthService", typeof(UserAuthService)))
            {
                service.Open();
                using (WCFService authservice = new WCFService("AppAuthService", typeof(AppAuthService)))
                {
                    authservice.Open();


                    Console.ReadLine();
                }
                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}