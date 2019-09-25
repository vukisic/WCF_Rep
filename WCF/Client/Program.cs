using Common.Contracts;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static IUserAuthContract authService;
        static string token = null;
        static void Main(string[] args)
        {
            authService = WCFClient.GetInstance().GetConnection<IUserAuthContract>("AuthService");
            int op = 0;
            do
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("1. LogIn");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. LogOut");
                Console.WriteLine("0. Exit");
                Console.Write(">>");
                bool input = Int32.TryParse(Console.ReadLine(),out op);
                if (input)
                {
                    switch (op)
                    {
                        case 1: LogIn();    break;
                        case 2: Register(); break;
                        case 3: LogOut();   break;
                        case 0:             break;
                        default: Console.WriteLine("Option error!");break;
                    }
                }

            } while (op != 0);

            Console.ReadLine();
            authService = null;
        }

        public static void LogIn()
        {
            if(token == null)
            {
                string username, password;
                Console.Write("Username:");
                username = Console.ReadLine();
                Console.Write("Password:");
                password = Console.ReadLine();

                if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
                    return;

                try
                {
                    LogInCredentials cred = new LogInCredentials(username, password);
                    token = authService.LogIn(cred);
                    Console.WriteLine($"--> Logged In! <--");
                }
                catch (FaultException ex)
                {
                    token = null;
                    Console.WriteLine($"--> {ex.Message} <--");

                }
            }
            else
            {
                Console.WriteLine("--> Already Logged In! <--");
            }
            
        }

        public static void LogOut()
        {
            if (token != null)
            {
                authService.LogOut(token);
                token = null;
                Console.WriteLine("--> Logged Out! <--");
            }
            else
            {
                Console.WriteLine("--> Not Logged In! <--");
            }
        }

        public static void Register()
        {
            if (token == null)
            {
                string username, password,name;
                Console.Write("Name:");
                name = Console.ReadLine();
                Console.Write("Username:");
                username = Console.ReadLine();
                Console.Write("Password:");
                password = Console.ReadLine();

                if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(name))
                    return;

                try
                {
                    RegisterCredentials cred = new RegisterCredentials(name, username, password);
                    token = authService.Register(cred);
                    Console.WriteLine($"--> Logged In! <--");
                }
                catch (FaultException ex)
                {
                    token = null;
                    Console.WriteLine($"--> {ex.Message} <--");
                }
            }
            else
            {
                Console.WriteLine("--> Already Logged In! <--");
            }
        }
    }
}
