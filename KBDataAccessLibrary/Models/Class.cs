using System;
using System.Collections.Generic;
using System.Text;

namespace KBDataAccessLibrary.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public AgeCategory AgeCategory { get; set; }
        public Group Group { get; set; }
        public List<Instructor> Instructors { get; set; }
    }
}
