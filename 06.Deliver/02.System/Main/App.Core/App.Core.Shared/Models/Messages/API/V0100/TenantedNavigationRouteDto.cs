namespace App.Core.Shared.Models.Messages.API.V0100
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class TenantedNavigationRouteDto : /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */  IHasGuidId
    {
        public Guid Id
        {
            get; set;
        }
        public bool Enabled { get; set; }

        public Guid OwnerFK
        {
            get; set;
        }

        public string Text
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
        public int DisplayOrderHint
        {
            get; set;
        }
        public string DisplayStyleHint
        {
            get; set;
        }

        public ICollection<TenantedNavigationRouteDto> Chilldren
        {
            get
            {
                return this._children ?? (this._children = new Collection<TenantedNavigationRouteDto>());
            }
        }

        private ICollection<TenantedNavigationRouteDto> _children;
    }
}