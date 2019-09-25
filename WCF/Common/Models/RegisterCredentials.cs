using Common.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [DataContract]
    public class RegisterCredentials
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }

        public RegisterCredentials(string name, string username, string password )
        {
            this.Name = name;
            this.Username = username;
            using(AesCipher aes = new AesCipher())
            {
                this.Password = aes.Encrypt(password);
            }
        }
    }
}
