using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Models.Messages.API.V0100
{
    public class GeoInformationDto
    {
        public GeoInformationCountryRegionDto CountryRegion { get; set; }

        public string IPAddress { get; set; }
    }

    public class GeoInformationCountryRegionDto
    {
        public string IsoCode { get; set; }
    }
}
