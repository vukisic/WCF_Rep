using Common.Cryptography;
using System.Runtime.Serialization;

namespace Common.Models
{
    [DataContract]
    public class LogInCredentials
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        public LogInCredentials(string username, string password)
        {
            this.Username = username;
            using (SHA1Manager sha = new SHA1Manager())
            {
                this.Password = sha.ComputeHash(password);
            }
        }
    }
}