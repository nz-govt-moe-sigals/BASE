using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Models.Messages
{
    /// <summary>
    /// A model of geo coordinates.
    /// <para>
    /// Used as a Query object by the IGeoLocationService. Or part of the Response.
    /// </para>
    /// </summary>
    public class GeoInformation
    {
        public GeoInformationCountryRegion CountryRegion { get; set; }

        public string IPAddress { get; set; }
    }

}
