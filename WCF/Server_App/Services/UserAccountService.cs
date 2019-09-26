using Common.Contracts;
using Common.Cryptography;
using Server_App.Access;
using System;
using System.ServiceModel;

namespace Server_App.Services
{
    public class UserAccountService : IUserAccountContract
    {
        private IAppRepository repo;
        private IAesCipher cipher;
        private IAppAuthContract authService;
        public  UserAccountService()
        {
            repo = new AppRepository();
            cipher = new AesCipher();
            authService = null;
            authService = WCFClient.GetInstance().GetConnection<IAppAuthContract>("AuthService");
        }

        public bool Deposite(string token, double amount)
        {
            var username = cipher.Decrypt(token);
            if (authService.IsAuthenticate(username))
            {
                var result = repo.Deposite(username, amount);
                if (result)
                    return true;
                throw new FaultException("Cannot deposite!");
            }
            throw new FaultException("Not Authenticate!");
        }

        public double State(string token)
        {
            var username = cipher.Decrypt(token);
            if (authService.IsAuthenticate(username))
            {
                try
                {
                    return repo.State(username);
                }
                catch (Exception)
                {
                    throw new FaultException("Account doesn't exist!");
                }
            }
            throw new FaultException("Not Authenticate!");
            
        }

        public bool Withdraw(string token, double amount)
        {
            var username = cipher.Decrypt(token);
            if (authService.IsAuthenticate(username))
            {
                var result = repo.Withdraw(username, amount);
                if (result)
                    return true;
                throw new FaultException("Cannot withdraw!");
            }
            throw new FaultException("Not Authenticate!");
           
        }
    }
}