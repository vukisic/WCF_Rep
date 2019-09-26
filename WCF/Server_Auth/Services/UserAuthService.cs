using Common.Contracts;
using Common.Cryptography;
using Common.Models;
using Server_Auth.Access;
using System.ServiceModel;

namespace Server_Auth.Services
{
    public class UserAuthService : IUserAuthContract
    {
        private IAuthRepository repo;
        private IAesCipher cipher;

        public UserAuthService()
        {
            repo = new AuthRepository();
            cipher = new AesCipher();
        }

        public string LogIn(LogInCredentials credentials)
        {
            if (repo.LogIn(credentials))
            {
                return repo.GenerateToken(credentials.Username);
            }
            throw new FaultException("Authentication Failed!");
        }

        public bool LogOut(string token)
        {
            string username = cipher.Decrypt(token);
            return repo.LogOut(username);
        }

        public string Register(RegisterCredentials credentials)
        {
            if (repo.Register(credentials))
            {
                return repo.GenerateToken(credentials.Username);
            }
            throw new FaultException("User already exist!");
        }
    }
}