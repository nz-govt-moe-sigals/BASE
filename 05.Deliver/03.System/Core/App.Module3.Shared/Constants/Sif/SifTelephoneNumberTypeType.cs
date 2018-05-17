using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Shared.Constants.Sif
{
    /// <summary>
    /// http://specification.sifassociation.org/Implementation/NZ/1/CodeSets.html#AUCodeSetsTelephoneNumberTypeType
    /// </summary>
    public enum SifTelephoneNumberTypeType
    {
        [Description("0096")]
        Main,
        [Description("2364")]
        Fax 
    }
}
