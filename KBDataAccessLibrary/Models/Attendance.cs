using System;
using System.Collections.Generic;
using System.Text;

namespace KBDataAccessLibrary.Models
{
    public class Attendance
    {
        public Student Student { get; set; }
        public Class Class { get; set; }
    }
}
