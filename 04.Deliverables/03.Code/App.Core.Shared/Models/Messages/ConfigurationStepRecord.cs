
namespace App.Core.Shared.Models.Messages
{
    using System;
    using App.Core.Shared.Factories;

    // A record of a configuration step that was undertaken.
    // For use by support personnel remotely reviewing configuration.
    public class ConfigurationStepRecord : IHasGuidId
    {
        // Note than although this model is not persisted in 
        // a datastore, an Id is still required, as it is expressed
        // via OData.
        public ConfigurationStepRecord()
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
