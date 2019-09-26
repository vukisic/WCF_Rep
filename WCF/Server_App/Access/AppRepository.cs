using Common.Cryptography;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_App.Access
{
    public class AppRepository : IAppRepository
    {
        private DataContext context;
        private IAesCipher cipher;

        public AppRepository()
        {
            context = new DataContext();
            cipher = new AesCipher();
        }

        public bool Deposite(string username, double amount)
        {
            var user = context.Products.Include(x => x.Account).SingleOrDefault(x => x.Username == username);
            if (user != null)
            {
                user.Account.Amount += amount;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public double State(string username)
        {
            var user = context.Products.Include(x=>x.Account).SingleOrDefault(x => x.Username == username);
            if (user != null)
            {
                return user.Account.Amount;
            }
            throw new ArgumentNullException();
        }

        public bool Withdraw(string username, double amount)
        {
            var user = context.Products.Include(x => x.Account).SingleOrDefault(x => x.Username == username);
            if (user != null)
            {
                if(user.Account.Amount - amount >= 0)
                {
                    user.Account.Amount -= amount;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
