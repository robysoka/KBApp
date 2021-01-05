using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KBDataAccessLibrary.Models.RegisterModels
{
    public class Invitation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid InvitationString { get; set; }
        public string Belt { get; set; }

        [Required]
        public AgeCategory AgeCategory { get; set; }

        [Required]
        public Group Group { get; set; }
        
        [Required]
        public DateTime ExpireDate { get; set; }
    }
}
