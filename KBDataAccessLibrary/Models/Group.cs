using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KBDataAccessLibrary.Models
{
    public class Group
    {
        public int GroupId { get; set; }

        [Required]
        [MaxLength(15)]
        [Column(TypeName ="varchar(15)")]
        public string GroupName { get; set; }
        
        [Required]
        virtual public AgeCategory AgeCategory { get; set; }
        public List<Student> Students { get; set; }
    }
}
