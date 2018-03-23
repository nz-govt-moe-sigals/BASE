using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Models.Messages.APIs.V0100
{
    using App.Core.Shared.Models.Configuration;

    /// <summary>
    /// DTO Message for <see cref="ApplicationDescription"/>
    /// summarizing the Application's Name, Description, Creator, Distributor.
    /// For use by any User Agent to render on their Header View.
    /// </summary>
    /// <seealso cref="App.Core.Shared.Models.IHasGuidId" />
    public class ApplicationDescriptionDto : IHasGuidId
    {
        public Guid Id
        {
            get; set;
        }


        public string Name { get; set; }

        public string Description
        {
            get; set;
        }

        public ApplicationProviderInformationDto Creator { get; set; }

        public ApplicationProviderInformationDto Distributor 
        {
            get; set;
        }
    }
}
