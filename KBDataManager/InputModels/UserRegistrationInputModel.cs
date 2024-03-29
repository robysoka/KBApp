﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KBDataManager.InputModels
{
    public class UserRegistrationInputModel
    {

        //FROM FRONTEND CLIENT
        [Required]
        public string InvitationHash { get; set; }

        //FROM USER
        [Required]
        public string InvitationCode { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string Belt { get; set; }

        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public int GroupId { get; set; }

    }
}
