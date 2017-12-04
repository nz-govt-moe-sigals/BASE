namespace App.Core.Shared.Models.Messages.APIs.V0100
{
    using System;

    public class PrincipalTagDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */
    {
        public virtual Guid Id { get; set; }

        public virtual bool Enabled { get; set; }

        public virtual string Text { get; set; }

        public virtual int DisplayOrderHint { get; set; }

        public virtual string DisplayStyleHint { get; set; }

    }
}