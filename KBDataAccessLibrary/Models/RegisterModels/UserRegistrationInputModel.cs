using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KBDataAccessLibrary.Models.RegisterModels
{
    public class UserRegistrationInputModel
    {
        [Required]
        public Guid InvitationString { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

    }
}
