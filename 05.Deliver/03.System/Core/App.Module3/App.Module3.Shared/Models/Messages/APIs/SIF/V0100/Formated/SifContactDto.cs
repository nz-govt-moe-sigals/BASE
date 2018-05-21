using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Shared.Models.Messages.APIs.SIF.V0100.Formated
{
    public class SifContactDto
    {
        public SifContactNameDto Name { get; set; }

        public string PositionTitle { get; set; }

        public string Role { get; set; }

        public ICollection<SifAddressDto> AddressList { get; set; }

        public ICollection<SifEmailDto> EmailList { get; set; }

        public ICollection<SifPhoneNumberDto> PhoneNumberList { get; set; }
    }
}
