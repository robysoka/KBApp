using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KBDataAccessLibrary.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }

        [Required]
        public Student Student { get; set; }

        [Required]
        public Class Class { get; set; }
    }
}
