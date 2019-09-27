using System.Runtime.Serialization;

namespace Common.Models
{
    [DataContract(IsReference = true)]
    public class AppUser
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string PasswordHash { get; set; }
        [DataMember]
        public UserAccount Account { get; set; }
        [DataMember]
        public bool IsAuth { get; set; }
        [DataMember]
        public int AccountId { get; set; }
    }
}