namespace App.Module02.Shared.Models.Messages.V0100
{
    using System;
    using App.Core.Shared.Factories;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.BaseClasses;

    public class BodyCategoryDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : TenantedRecordStateGuidIdReferenceDtoBase,  IHasGuidId, IHasTenantFK, IHasRecordState
    {
    }

}