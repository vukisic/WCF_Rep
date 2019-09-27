using System.Runtime.Serialization;

namespace Common.Models
{
    [DataContract(IsReference = true)]
    public class UserAccount
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public double Amount { get; set; }
        [DataMember]
        public AppUser User { get; set; }
        [DataMember]
        public int UserId { get; set; }
    }
}