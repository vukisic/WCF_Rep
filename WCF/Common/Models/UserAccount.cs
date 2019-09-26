namespace Common.Models
{
    public class UserAccount
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public AppUser User { get; set; }
        public int UserId { get; set; }
    }
}