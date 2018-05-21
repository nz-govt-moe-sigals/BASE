using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Shared.Constants.Sif
{
    /// <summary>
    /// http://specification.sifassociation.org/Implementation/NZ/1/CodeSets.html#NZCodeSetsOrganisationTypeType
    /// </summary>
    public enum  SifOrganisationTypeType
    {
        [Description("101")]
        CommunityOfLearning,
        [Description("102")]
        MinistryOfEducationLocalOffice
    }
}
