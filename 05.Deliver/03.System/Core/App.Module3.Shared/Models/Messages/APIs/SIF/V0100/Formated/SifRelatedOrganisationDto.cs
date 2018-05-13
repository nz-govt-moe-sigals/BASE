using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Shared.Models.Messages.APIs.SIF.V0100.Formated
{
    public class SifRelatedOrganisationDto
    {
        public string RefId { get; set; }

        public string LocalId { get; set; }

        public string Name { get; set; }

        public string ObjectType { get; set; }

        public string OrangisationType { get; set; }
    }
}
