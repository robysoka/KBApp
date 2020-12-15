using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KBDataAccessLibrary.Models
{
    public class AgeCategory
    {
        public int AgeCategoryId { get; set; }

        [Required]
        [MaxLength(7)]
        [Column(TypeName ="varchar(7)")]
        public string CategoryName { get; set; }
        public List<Student> Students { get; set; } 

    }
}
