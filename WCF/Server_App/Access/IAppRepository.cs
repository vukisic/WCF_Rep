using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_App.Access
{
    public interface IAppRepository
    {
        bool Deposite(string username, double amount);
        bool Withdraw(string username, double amount);
        double State(string username);
    }
}
