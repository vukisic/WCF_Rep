using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Auth.Access
{
    public interface IAuthRepository
    {
        bool LogIn(LogInCredentials credentials);
        bool Register(RegisterCredentials credentials);

        bool isAuthenticate(string username);
        string GenerateToken(string username);
        bool LogOut(string username);
    }
}
