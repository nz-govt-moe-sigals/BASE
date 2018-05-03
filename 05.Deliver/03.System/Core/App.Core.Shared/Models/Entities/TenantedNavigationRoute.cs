using System;
using System.Collections.Generic;

namespace App.Core.Shared.Models.Entities
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// A single element within a Navigation Map used by user interfaces.
    /// <see cref="NavigationRoute"/>.
    /// </summary>
    /// <seealso cref="App.Core.Shared.Models.Entities.TenantFKTimestampedAuditedRecordStatedGuidIdEntityBase" />
    /// <seealso cref="App.Core.Shared.Models.IHasGuidId" />
    /// <seealso cref="App.Core.Shared.Models.IHasOwnerFK" />
    /// <seealso cref="App.Core.Shared.Models.IHasText" />
    /// <seealso cref="App.Core.Shared.Models.IHasDescription" />
    /// <seealso cref="App.Core.Shared.Models.IHasDisplayOrderHint" />
    /// <seealso cref="App.Core.Shared.Models.IHasDisplayStyleHint" />
    public class TenantedNavigationRoute : TenantFKTimestampedAuditedRecordStatedGuidIdEntityBase, IHasGuidId, IHasOwnerFK, IHasText, IHasDescription, IHasDisplayOrderHint, IHasDisplayStyleHint
    {
        public bool Enabled
        {
            get; set;
        }

        public Guid OwnerFK { get; set; }

        public string Text { get; set; }
        public string Description { get; set; }
        public int DisplayOrderHint { get; set; }
        public string DisplayStyleHint { get; set; }

        public ICollection<TenantedNavigationRoute> Chilldren {
            get
            {
                return _children ?? (_children = new Collection<TenantedNavigationRoute>());
            }
        }

        private ICollection<TenantedNavigationRoute> _children;
    }
}
