using Common.Cryptography;
using Common.Models;
using System.Linq;

namespace Server_Auth.Access
{
    public class AuthRepository : IAuthRepository
    {
        private DataContext context;
        private IAesCipher cipher;

        public AuthRepository()
        {
            context = new DataContext();
            cipher = new AesCipher();
        }

        public string GenerateToken(string username)
        {
            return cipher.Encrypt(username);
        }

        public bool IsAuthenticate(string username)
        {
            var user = context.Products.SingleOrDefault(x => x.Username == username);
            if (user != null)
            {
                return user.IsAuth != false;
            }
            return false;
        }

        public bool LogIn(LogInCredentials credentials)
        {
            var user = context.Products.SingleOrDefault(x => x.Username == credentials.Username);
            if (user != null)
            {
                if (user.PasswordHash == credentials.Password)
                {
                    user.IsAuth = true;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool LogOut(string username)
        {
            var user = context.Products.SingleOrDefault(x => x.Username == username);
            if (user != null)
            {
                user.IsAuth = false;
                context.SaveChanges();
                return false;
            }
            return false;
        }

        public bool Register(RegisterCredentials credentials)
        {
            var user = context.Products.SingleOrDefault(x => x.Username == credentials.Username);
            if (user == null)
            {
                var newUser = new AppUser()
                {
                    IsAuth = true,
                    Name = credentials.Name,
                    PasswordHash = credentials.Password,
                    Username = credentials.Username,
                    Account = new UserAccount()
                };
                context.Products.Add(newUser);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}