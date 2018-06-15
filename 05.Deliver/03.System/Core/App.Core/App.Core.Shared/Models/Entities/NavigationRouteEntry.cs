namespace App.Core.Shared.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// An untenanted (ie, Universal/App) Navigation route entry.
    /// <see cref="TenantedNavigationRoute"/>
    /// </summary>
    /// <seealso cref="App.Core.Shared.Models.Entities.UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase" />
    /// <seealso cref="App.Core.Shared.Models.IHasGuidId" />
    /// <seealso cref="App.Core.Shared.Models.IHasOwnerFK" />
    /// <seealso cref="App.Core.Shared.Models.IHasText" />
    /// <seealso cref="App.Core.Shared.Models.IHasDescription" />
    /// <seealso cref="App.Core.Shared.Models.IHasDisplayOrderHint" />
    /// <seealso cref="App.Core.Shared.Models.IHasDisplayStyleHint" />
    public class NavigationRoute : UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase, IHasGuidId, IHasOwnerFK, IHasText, IHasDescription, IHasDisplayOrderHint, IHasDisplayStyleHint
    {
        public Guid OwnerFK
        {
            get; set;
        }

        public bool Enabled
        {
            get; set;
        }

        public string Title
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

        public ICollection<NavigationRoute> Chilldren
        {
            get
            {
                return this._children ?? (this._children = new Collection<NavigationRoute>());
            }
        }

        private ICollection<NavigationRoute> _children;
    }
}