using System;
using System.Collections.Generic;
using System.Text;

namespace KBDataAccessLibrary.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public AgeCategory AgeCategory { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
