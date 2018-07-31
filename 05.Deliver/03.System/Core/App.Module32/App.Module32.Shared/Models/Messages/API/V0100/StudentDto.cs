using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module32.Shared.Models.Messages.API.V0100
{
    public class StudentDto
    {
        public string StudentId { get; set; }

        public string DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string FullName { get; set; }

        public int SchoolId { get; set; }
    }
}
