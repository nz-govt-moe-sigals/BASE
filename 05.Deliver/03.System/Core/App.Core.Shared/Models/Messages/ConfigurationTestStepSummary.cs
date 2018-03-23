using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Models.Messages
{
    using App.Core.Shared.Factories;

    // A model to hold the results of a 
    // self assessement of integration, etc.
    // Again, this is to provide to support
    // stakeholders a way of ensuring the system
    // is up and running.
    public class ConfigurationTestStepSummary : IHasGuidId
    {
        // Note than although this model is not persisted in 
        // a datastore, an Id is still required, as it is expressed
        // via OData.
        public ConfigurationTestStepSummary()
        {
            this.Id = GuidFactory.NewGuid();
        }
        public Guid Id { get; set; }

        public ConfigurationStepType Type { get; set; }
        public ConfigurationStepStatus Status { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
