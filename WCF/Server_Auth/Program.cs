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

                Console.ReadLine();
            }
        }
    }
}