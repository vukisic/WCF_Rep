using Server_Rep.Services;
using System;

namespace Server_Rep
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (WCFService service = new WCFService("ReplicationService",typeof(ReplicationService)))
            {
                service.Open();

                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}