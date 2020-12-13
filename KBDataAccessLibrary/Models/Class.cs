﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public AgeCategory AgeCategory { get; set; }

        [Required]
        public Group Group { get; set; }
        public List<Instructor> Instructors { get; set; } = new List<Instructor>;
    }
}
