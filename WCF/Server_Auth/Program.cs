using Common.Contracts;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using Server_Auth.Access;
using Server_Auth.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Server_Auth
{
    internal class Program
    {
        static IReplicationContract repService;
        private static void Main(string[] args)
        {
            repService = WCFClient.GetInstance().GetConnection<IReplicationContract>("ReplicationService");

            Task.Run(() =>
            {
                Replicate();
            });

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

        private static void Replicate()
        {
            while (true)
            {
                GetData(repService.GetData());
                Thread.Sleep(3000);
                repService.SendData(SendData());
                Thread.Sleep(3000);
            }
        }

        private static void GetData(List<AppUser> list)
        {
            using(DataContext context = new DataContext())
            {
                foreach (var item in list)
                {
                    if(context.Products.SingleOrDefault(x=>x.Username==item.Username) == null)
                    {
                        context.Add(item);
                        context.SaveChanges();
                    }
                }
            }
        }

        private static List<AppUser> SendData()
        {
            using(DataContext context = new DataContext())
            {
                return context.Products.Include(x => x.Account).ToList();
            }
        }
    }
}