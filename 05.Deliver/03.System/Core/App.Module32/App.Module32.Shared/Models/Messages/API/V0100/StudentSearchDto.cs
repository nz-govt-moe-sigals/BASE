using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module32.Shared.Models.Messages.API.V0100
{
    public class StudentSearchDto
    {
        public string NSN { get; set; }

        public int? SchoolId { get; set; }

        public string Gender { get; set; }

        public string SchoolName { get; set; }

        public string StudentName { get; set; }

        public DateTime? DateOfBirth { get; set; }

    }
}
