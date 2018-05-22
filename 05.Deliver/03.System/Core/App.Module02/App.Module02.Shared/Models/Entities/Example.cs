namespace App.Module02.Shared.Models.Entities
{
    using App.Core.Shared.Models.Entities;

    public class Example : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase
    {
        // A Field to save current User name (only used to demonstrate Filtering) 
        public virtual string Owner { get; set; }

        // An example of a Public Field safe to show all people
        public virtual string PublicText { get; set; }

        // An example of a Sensitive Field that is exposed depending on Claims.
        public virtual string SensitiveText { get; set; }

        // An example of a App-Private Field that should not be exposed outside the system
        public virtual string AppPrivateText { get; set; }
    }
}

