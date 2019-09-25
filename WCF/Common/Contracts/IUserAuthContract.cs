using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts
{
    public interface IUserAuthContract
    {
        string LogIn(LogInCredentials credentials);
        string Register();
    }
}
