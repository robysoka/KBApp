using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KBDataAccessLibrary.Models
{
    public class Competition
    {
        [Required]
        public int CompetitionId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CompetitionName { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
    }
}
