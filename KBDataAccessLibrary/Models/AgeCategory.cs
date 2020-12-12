using System;
using System.Collections.Generic;
using System.Text;

namespace KBDataAccessLibrary.Models
{
    public class AgeCategory
    {
        public int AgeCategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

    }
}
