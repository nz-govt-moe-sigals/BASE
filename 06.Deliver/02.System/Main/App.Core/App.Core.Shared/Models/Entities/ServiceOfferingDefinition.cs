using App.Core.Shared.Models.Entities.Base;
using System;

namespace App.Core.Shared.Models.Entities
{
    /// <summary>
    ///  A Join object between a <see cref="ServicePlanDefinition"/>
    ///  and <see cref="ServiceDefinition"/>.
    /// </summary>
    public class ServiceOfferingDefinition : UntenantedAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase, IHasKey
    {

        /// <summary>
        /// The (indexed) unique Key for this Offering
        /// </summary>
        public virtual string Key { get; set; }

        /// <summary>
        ///  The FK of the child <see cref="ServiceDefinition"/>
        /// </summary>
        public virtual Guid ServiceFK { get; set; }
        /// <summary>
        ///  The child <see cref="ServiceDefinition"/>
        /// </summary>
        public virtual ServiceDefinition Service {get;set;}


        public int PrincipalLimit { get; set; }
        public int ResourceLimit { get; set; }

        /// <summary>
        /// Price/Month
        /// <para>
        /// This billing only comes into effect if the
        /// Service is associated directly to a 
        /// <see cref="TenantServiceProfile"/>
        /// </para>
        /// <para>
        /// Used to set the CostPerMonth within a
        /// <see cref="TenantServiceProfileServiceOfferingAllocation"/>,
        /// which can be overridden as needed by other logic (freebie, etc).
        /// </para>
        /// </summary>
        public virtual decimal DefaultCostPerMonth { get; set; }

        /// <summary>
        /// Price/Year if a year is signed up for.
        /// <para>
        /// This billing only comes into effect if the
        /// Service is associated directly to a 
        /// <see cref="TenantServiceProfile"/>
        /// </para>
        /// <para>
        /// Used to set the CostPerMonth within a
        /// <see cref="TenantServiceProfileServiceOfferingAllocation"/>,
        /// which can be overridden as needed by other logic (freebie, etc).
        /// </para>
        /// </summary>
        public virtual decimal DefaultCostPerYear { get; set; }

        ///// <summary>
        ///// The collection of optional limits (users, resources, etc).
        ///// <para>
        ///// An example limit would be when a 
        ///// "Basic" ServicePlanDefinition allows for 5 Users, and
        ///// only the creation of 1 of this type of Resource.
        ///// </para>
        ///// </summary>
        //public ICollection<ServiceOfferingDefinitionLimit> Limits {
        //    get { return _limits ?? (_limits = new Collection<ServiceOfferingDefinitionLimit>()); }
        //}
        //ICollection<ServiceOfferingDefinitionLimit> _limits;


    }

}
