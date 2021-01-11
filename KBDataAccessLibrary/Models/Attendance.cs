using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KBDataAccessLibrary.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }

        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        virtual public Student Student { get; set; }


        [Required]
        [ForeignKey("Class")]
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
