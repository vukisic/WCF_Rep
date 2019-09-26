using Common.Contracts;
using Server_Auth.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Auth.Services
{
    public class AppAuthService : IAppAuthContract
    {
        private IAuthRepository repo;
        public AppAuthService()
        {
            repo = new AuthRepository();
        }

        public bool IsAuthenticate(string username)
        {
            try
            {
                return repo.IsAuthenticate(username);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
