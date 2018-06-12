using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Shared.Models.Entities;
using App.Core.Shared.Models.Entities.Base;

namespace App.Module32.Shared.Models.Entities
{
    public class EducationStudentProfile : ExtractDataBase
    {
        public string NSN { get; set; }

        

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string FullName { get; set; }

        public Guid EducationSchoolProfileFK { get; set; }

        public EducationSchoolProfile EducationSchoolProfile { get; set; }
    }
}
