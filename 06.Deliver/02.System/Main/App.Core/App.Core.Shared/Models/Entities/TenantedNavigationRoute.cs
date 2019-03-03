using System;
using System.Collections.Generic;

namespace App.Core.Shared.Models.Entities
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// A single element within a Navigation Map used by user interfaces.
    /// <see cref="NavigationRoute"/>.
    /// </summary>
    /// <seealso cref="App.Core.Shared.Models.Entities.TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase" />
    /// <seealso cref="App.Core.Shared.Models.IHasGuidId" />
    /// <seealso cref="App.Core.Shared.Models.IHasText" />
    /// <seealso cref="App.Core.Shared.Models.IHasDescription" />
    /// <seealso cref="App.Core.Shared.Models.IHasDisplayOrderHint" />
    /// <seealso cref="App.Core.Shared.Models.IHasDisplayStyleHint" />
    public class TenantedNavigationRoute : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasGuidId, IHasOwnerFK, IHasText, IHasDescription, IHasDisplayOrderHint, IHasDisplayStyleHint
    {

        public bool Enabled {get; set;}
        // Class Not even used not sure what this was supposed to be
        public Guid OwnerFK { get; set; }

        public string Title { get; set; }
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

        public Guid GetOwnerFk()
        {
            return OwnerFK;
        }
    }
}
