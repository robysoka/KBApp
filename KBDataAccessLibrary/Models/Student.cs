using KBDataAccessLibrary.Models.LoginModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KBDataAccessLibrary.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string FirstName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string Belt { get; set; }

        [Required]
        public AgeCategory AgeCategory { get; set; }

        [Required]
        public Group Group { get; set; }

        [Required]
        public User User { get; set; }

        public List<Membership> Memberships { get; set; }
    }
}
