using System;
using System.Collections.Generic;
using System.Text;

namespace KBDataAccessLibrary.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public List<Class> Classes { get; set; }
    }
}
