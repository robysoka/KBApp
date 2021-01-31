using KBDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KBDataManager.ViewModels
{
    public class StudentDataViewModel
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Belt { get; set; }
    }
}
