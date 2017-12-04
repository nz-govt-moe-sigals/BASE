namespace App.Module2.Shared.Models.Entities
{
    using System;
    using App.Core.Shared.Models.Entities;

    public class EducationOrganisation : TenantFKTimestampedAuditedRecordStatedGuidIdEntityBase
    {
        public virtual Guid? ParentFK { get; set; }

        public virtual SchoolEstablishmentType Type { get; set; }

        public virtual string Key { get; set; }
        public virtual string Description { get; set; }

        public virtual Guid OrganisationFK { get; set; }
        public virtual Body Organisation { get; set; }

        //FK to Principal Body
        public virtual Guid PrincipalFK { get; set; }

        public virtual Body Principal { get; set; }


        public virtual string Note { get; set; }
    }
}