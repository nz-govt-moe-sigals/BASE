namespace App.Core.Shared.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Session : UntenantedTimestampedAuditedRecordStatedGuidIdEntityBase, IHasEnabled, IHasPrincipalFK
    {
        public Session():base()
        {
            Enabled = true;
        }

        public virtual bool Enabled { get; set; }

        public virtual Guid PrincipalFK { get; set; }
        public virtual Principal Principal { get; set; }

        // A Session is bound to a Principal, 
        // but not Bound to a single Tenant (as a User
        // can switch Tenants):
        // NO: public Tenant Tenant { get; set; }
        // NO: public Guid TenantFK { get; set; }


        public virtual ICollection<SessionOperation> Operations
        {
            get
            {
                if (this._operations == null)
                {
                    this._operations = new Collection<SessionOperation>();
                }
                return this._operations;
            }
            set => this._operations = value;
        }
        private ICollection<SessionOperation> _operations;

    }
}