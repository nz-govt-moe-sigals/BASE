using System;
using System.Collections.Generic;

namespace App.Module33.Shared.Models.Entities
{
    using App.Core.Shared.Models.Entities;

    public class Community : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase
    {
        // A Field to save current User name (only used to demonstrate Filtering) 
        public string Owner { get; set; }

        // An example of a Public Field safe to show all people
        public string PublicText { get; set; }

        // An example of a Sensitive Field that is exposed depending on Claims.
        public string SensitiveText { get; set; }

        // An example of a App-Private Field that should not be exposed outside the system
        public string AppPrivateText { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid ColourSchemeFK { get; set; }

        public CommunityColourScheme ColourScheme { get; set; }

        public string Strategy { get; set; }

        public virtual ICollection<CoherentPathway> CoherentPathways { get; set; }
    }
}

