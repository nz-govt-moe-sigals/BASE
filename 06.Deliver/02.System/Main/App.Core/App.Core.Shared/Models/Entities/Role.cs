namespace App.Core.Shared.Models.Entities
{
    /// <summary>
    ///     Roles within this System (not the same as Claims Roles that came in via remote IdP)
    /// And not the same as custom Tenant roles (still to solve).
    /// </summary>
    public class SystemRole : UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase, IHasEnabled, IHasKey
    {
        public virtual bool Enabled { get; set; }

        /// <summary>
        /// Module within which the Role was developed/designed for.
        /// </summary>
        public virtual string ModuleKey { get; set; }

        /// <summary>
        ///     The in-system rolename.
        /// </summary>
        public virtual string Key { get; set; }


        public virtual NZDataClassification? DataClassificationFK { get; set; }
        public virtual DataClassification DataClassification { get; set; }
    }
}