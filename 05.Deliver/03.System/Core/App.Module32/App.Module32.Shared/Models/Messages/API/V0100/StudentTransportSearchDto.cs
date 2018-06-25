using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module32.Shared.Models.Messages.API.V0100
{
    public class StudentTransportSearchDto
    {

        // not sure is needed, but it's in here for future proofing atm
        public int? SchoolId { get; set; }

        public string SchoolName { get; set; }

        public string StudentName { get; set; }

        public DateTime? DateOfBirth { get; set; }

    }
}
