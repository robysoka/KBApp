using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        virtual public Student Student { get; set; }
    }
}
