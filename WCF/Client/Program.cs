using Common.Contracts;
using Common.Models;
using System;
using System.ServiceModel;

namespace Client
{
    internal class Program
    {
        private static IUserAuthContract authService;
        private static IUserAccountContract appService;
        private static string token = null;

        private static void Main(string[] args)
        {
            authService = WCFClient.GetInstance().GetConnection<IUserAuthContract>("AuthService");
            appService = WCFClient.GetInstance().GetConnection<IUserAccountContract>("AppService");
            int op = 0;
            do
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("1. LogIn");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. LogOut");
                Console.WriteLine("4. State");
                Console.WriteLine("5. Deposite");
                Console.WriteLine("6. Withdraw");
                Console.WriteLine("0. Exit");
                Console.Write(">>");
                bool input = Int32.TryParse(Console.ReadLine(), out op);
                if (input)
                {
                    switch (op)
                    {
                        case 1: LogIn(); break;
                        case 2: Register(); break;
                        case 3: LogOut(); break;
                        case 4: State(); break;
                        case 5: Deposite(); break;
                        case 6: Withdraw(); break;
                        case 0: break;
                        default: Console.WriteLine("Option error!"); break;
                    }
                }
            } while (op != 0);

            Console.ReadLine();
            authService = null;
        }

        public static void LogIn()
        {
            if (token == null)
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
                string username, password, name;
                Console.Write("Name:");
                name = Console.ReadLine();
                Console.Write("Username:");
                username = Console.ReadLine();
                Console.Write("Password[4 chars]:");
                password = Console.ReadLine();

                if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(name))
                    return;

                if (password.Length != 4)
                {
                    Console.WriteLine("--> Password lenght must be 4 <--");
                }

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

        public static void State()
        {
            if (token != null)
            {
                try
                {
                    var result = appService.State(token);
                    Console.WriteLine($"State: {result} $");
                }
                catch (FaultException ex)
                {
                    Console.WriteLine($"--> {ex.Message} <--");
                }
            }
            else
            {
                Console.WriteLine("--> Not Logged In <--");
            }
        }

        public static void Deposite()
        {
            if (token != null)
            {
                try
                {
                    double amount = 0.0;
                    Console.Write("Amount:");
                    var result = Double.TryParse(Console.ReadLine(), out amount);
                    if (!result)
                        return;
                    result = appService.Deposite(token, amount);
                    Console.WriteLine("--> Success <--");
                }
                catch (FaultException ex)
                {
                    Console.WriteLine($"--> {ex.Message} <--");
                }
            }
            else
            {
                Console.WriteLine("--> Not Logged In <--");
            }
        }

        public static void Withdraw()
        {
            if (token != null)
            {
                try
                {
                    double amount = 0.0;
                    Console.Write("Amount:");
                    var result = Double.TryParse(Console.ReadLine(), out amount);
                    if (!result)
                        return;
                    result = appService.Withdraw(token, amount);
                    Console.WriteLine("--> Success <--");
                }
                catch (FaultException ex)
                {
                    Console.WriteLine($"--> {ex.Message} <--");
                }
            }
            else
            {
                Console.WriteLine("--> Not Logged In <--");
            }
        }
    }
}