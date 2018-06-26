using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module80.Shared.Models.Messages.API
{
    public class RegionDto
    {
        public int RegionId { get; set; }

        public string Name { get; set; }

        public ICollection<SurveyLocationDto> Beaches { get; set; }
    }
}
