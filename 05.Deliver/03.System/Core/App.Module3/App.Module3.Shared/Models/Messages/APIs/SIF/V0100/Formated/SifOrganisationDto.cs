using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Shared.Models.Messages.APIs.SIF.V0100.Formated
{
    public class SifOrganisationDto
    {
        //public SifOrganisationDto()
        //{
        //    Id = Guid.NewGuid();
        //}

        //public Guid Id { get; set; }


        public virtual ICollection<SifAddressDto> AddressList { get; set; }

        public virtual ICollection<SifEmailDto> EmailList { get; set; }

        public virtual ICollection<SifPhoneNumberDto> PhoneNumberList { get; set; }

        public virtual ICollection<SifCommunicationChannelDto> CommunicationChannelList { get; set; }

        public virtual ICollection<SifContactDto> ContactList { get; set; }

        public string EducationRegion { get; set; }

        public string Name { get; set; }

        public virtual ICollection<SifRelatedOrganisationDto> RelatedOrganisationList { get; set; }

        public string OperationalStatus { get; set; }

        public string Type { get; set; }
    }
}
