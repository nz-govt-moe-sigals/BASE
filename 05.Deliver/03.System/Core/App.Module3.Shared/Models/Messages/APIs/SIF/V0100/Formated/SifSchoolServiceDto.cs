using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Shared.Models.Messages.APIs.SIF.V0100.Formated
{
    public class SifSchoolServiceDto
    {
        public int? Decile { get; set; }

        public string CoEdStatus { get; set; }

        public virtual ICollection<SifSchoolYearDto> SchoolYearList { get; set; }

        public virtual ICollection<SifEnactedPolicyDto> NewEntrantPolicyList { get; set; }

        public virtual ICollection<string> DefinitionList { get; set; } // hmmm generally speaking this is fairly bad because definition can't change at all once set
    }
}
