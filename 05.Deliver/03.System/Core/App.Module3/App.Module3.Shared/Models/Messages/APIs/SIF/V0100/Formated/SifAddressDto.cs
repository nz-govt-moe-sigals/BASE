using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Shared.Models.Messages.APIs.SIF.V0100.Formated
{
    public class SifAddressDto
    {
        public string Type { get; set; }

        public string Role { get; set; }

        public SifAddressStreetDto Street { get; set; }

        public string Suburb { get; set; }

        public string City { get; set; }

        public string StateProvince { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }
    }
}
