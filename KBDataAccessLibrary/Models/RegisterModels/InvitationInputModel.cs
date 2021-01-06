using System;
using System.Collections.Generic;
using System.Text;

namespace KBDataAccessLibrary.Models.RegisterModels
{
    public class InvitationInputModel
    {
        public string Email { get; set; }
        public string Belt { get; set; }
        public int AgeCategoryId { get; set; }
        public int GroupId { get; set; }
    }
}
