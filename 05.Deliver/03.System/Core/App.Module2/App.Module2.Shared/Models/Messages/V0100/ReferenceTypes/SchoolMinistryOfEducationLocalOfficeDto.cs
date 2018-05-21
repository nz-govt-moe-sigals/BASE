namespace App.Module02.Shared.Models.Messages.V0100
{
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Messages.BaseClasses;

    public class SchoolMinistryOfEducationLocalOfficeDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : TenantedRecordStateGuidIdReferenceDtoBase, IHasGuidId, IHasTenantFK, IHasRecordState
    {
    }
}