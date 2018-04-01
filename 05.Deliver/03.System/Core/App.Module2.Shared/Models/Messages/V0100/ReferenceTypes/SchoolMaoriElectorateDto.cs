﻿namespace App.Module2.Shared.Models.Messages.V0100
{
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Messages.BaseClasses;

    public class SchoolMaoriElectorateDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : ReferenceDtoBase, IHasGuidId, IHasTenantFK, IHasRecordState
    {
    }
}