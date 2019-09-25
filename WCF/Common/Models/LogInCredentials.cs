using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
            this.Password = password;
        }
    }
}
