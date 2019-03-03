using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Models.Messages.API.V0100
{
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;

    /// <summary>
    /// DTO Message for <see cref="ApplicationDescriptionConfigurationSettings"/>
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
