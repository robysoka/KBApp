using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KBDataAccessLibrary.Models
{
    public class Membership
    {
        public int MembershipId { get; set; }

        [Required]
        public DateTime LastPaid { get; set; }

        [Required]
        public DateTime ExpireTime { get; set; }

        [Required]
        virtual public Student Student { get; set; }
    }
}
