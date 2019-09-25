using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
