using App.Core.Shared.Models.Entities.Base;
using App.Module01.Shared.Models.Entities.Enums;

namespace App.Module01.Shared.Models.Entities
{
    /// <summary>
    /// The Type of a <see cref="CourseResource"/>.
    /// Can be a Location, Time, Object, License, Subscription.
    /// <para>
    /// Used by a <see cref="CourseResource"/>.
    /// </para>
    /// </summary>
    public class CourseResourceType : TenantFKAuditedRecordStatedTimestampedCustomIdReferenceDataEntityBase<CourseResourceEnumType>
    {
        //Ie, Title, Description, TenantFK, GuidId, RecordState, Audited
    }





}
