using System;
using System.Collections.Generic;
using System.Text;

namespace KBDataAccessLibrary.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Belt { get; set; }
        public AgeCategory AgeCategory { get; set; }
        public Group Group { get; set; }
        public List<Membership> Memberships { get; set; }
    }
}
