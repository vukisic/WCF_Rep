using Common.Contracts;
using Common.Cryptography;
using Server_App.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server_App.Services
{
    public class UserAccountService : IUserAccountContract
    {
        private IAppRepository repo;
        private IAesCipher cipher;

        public UserAccountService()
        {
            repo = new AppRepository();
            cipher = new AesCipher();
        }

        public bool Deposite(string token, double amount)
        {
            var username = cipher.Decrypt(token);
            var result = repo.Deposite(username, amount);
            if (result)
                return true;
            throw new FaultException("Cannot deposite!");
        }

        public double State(string token)
        {
            var username = cipher.Decrypt(token);
            try
            {
                return repo.State(username);
            }
            catch (Exception)
            {

                throw new FaultException("Account doesn't exist!");
            }
        }

        public bool Withdraw(string token, double amount)
        {
            var username = cipher.Decrypt(token);
            var result = repo.Withdraw(username, amount);
            if (result)
                return true;
            throw new FaultException("Cannot withdraw!");
        }
    }
}
