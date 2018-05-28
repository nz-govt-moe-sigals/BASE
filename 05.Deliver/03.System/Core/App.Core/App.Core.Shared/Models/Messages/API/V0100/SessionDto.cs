namespace App.Core.Shared.Models.Messages.API.V0100
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using App.Core.Shared.Models.Entities;

    public class SessionDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId, IHasEnabled
    {
        public virtual DateTime StartDateTimeUtc { get; set; }

        public virtual bool Enabled { get; set; }
        public virtual Guid Id { get; set; }
        public virtual Principal Principal { get; set; }


        public virtual ICollection<SessionOperationDto> Operations
        {
            get
            {
                if (this._operations == null)
                {
                    this._operations = new Collection<SessionOperationDto>();
                }
                return this._operations;
            }
            set => this._operations = value;
        }
        private ICollection<SessionOperationDto> _operations;
    }
}