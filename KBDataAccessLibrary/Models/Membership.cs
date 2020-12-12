using System;
using System.Collections.Generic;
using System.Text;

namespace KBDataAccessLibrary.Models
{
    public class Membership
    {
        public int MembershipId { get; set; }
        public DateTime LastPaid { get; set; }
        public DateTime ExpireTime { get; set; }
        public Student Student { get; set; }
    }
}
