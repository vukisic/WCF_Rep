using Common.Models;

namespace Server_Auth.Access
{
    public interface IAuthRepository
    {
        bool LogIn(LogInCredentials credentials);

        bool Register(RegisterCredentials credentials);

        bool IsAuthenticate(string username);

        string GenerateToken(string username);

        bool LogOut(string username);
    }
}