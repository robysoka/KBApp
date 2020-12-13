using System;
using System.Collections.Generic;
using System.Text;

namespace KBDataAccessLibrary.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public Student Student { get; set; }
        public Class Class { get; set; }
    }
}
