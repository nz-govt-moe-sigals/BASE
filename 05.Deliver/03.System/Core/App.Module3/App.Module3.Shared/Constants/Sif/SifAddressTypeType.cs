using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Shared.Constants.Sif
{
    /// <summary>
    /// http://specification.sifassociation.org/Implementation/NZ/1/CodeSets.html#NZCodeSetsAddressTypeType
    /// </summary>
    public enum SifAddressTypeType
    {
        [Description("1")]
        Thoroughfare,
        [Description("2")]
        Rural,
        [Description("3")]
        DeliveryService,
        [Description("4")]
        Water,
        [Description("5")]
        ForeignAddress
    }
}
