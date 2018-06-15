using App.Core.Shared.Models.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Models.Entities
{



    /// <summary>
    /// The Service Profile (ie Subscription)
    /// to which a <see cref="Plan"/> plan is associated.
    /// <para>
    /// We are not associating a <see cref="ServicePlan"/> 
    /// to a <see cref="Principal"/> directly
    /// to the 
    /// </para>
    /// </summary>
    public class TenantServiceProfile : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase {


        // Not needed: Already part of the base class:
        ////public virtual Guid TenantFK { get; set; }

        public virtual Tenant Tenant { get; set; }


        /// <summary>
        /// A <see cref="TenantServiceProfile"/> most often 
        /// will be signed up to one <see cref="ServiceProfile"/>.
        /// <para>
        /// But there are cases where the Tenancy is signed 
        /// up to multiple.
        /// </para>
        /// </summary>
        public virtual ICollection<TenantServiceProfileServicePlanAllocation> ServicePlans { 
            get { return _servicePlans ?? (_servicePlans = new Collection<TenantServiceProfileServicePlanAllocation>()); }
        }
        ICollection<TenantServiceProfileServicePlanAllocation> _servicePlans;


        /// <summary>
        /// The collection of direct Service Allocations.
        /// <para>
        /// Consider this as overrides of the default list of services 
        /// defined within the <see cref="ServicePlanDefinition"/>
        /// associated to this <see cref="TenantServiceProfile"/>.
        /// </para>
        /// </summary>
        public virtual ICollection<TenantServiceProfileServiceOfferingAllocation> Services {
            get { return _services ?? (_services = new Collection<TenantServiceProfileServiceOfferingAllocation>()); } }
        ICollection<TenantServiceProfileServiceOfferingAllocation> _services;

    }

}
