using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module80.Shared.Models.Messages.API
{
    public class OrganisationDto
    {
        public string Name { get; set; }

        public string ContactNumber { get; set; }

        public ICollection<SurveyDto> Surveys { get; set; }
    }
}
