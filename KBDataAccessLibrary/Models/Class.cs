using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KBDataAccessLibrary.Models
{
    public class Class
    {
        public int ClassId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }


        [Required]
        [ForeignKey("Group")]
        public int GroupId { get; set; }
        virtual public Group Group { get; set; }
        public List<Instructor> Instructors { get; set; }
    }
}
