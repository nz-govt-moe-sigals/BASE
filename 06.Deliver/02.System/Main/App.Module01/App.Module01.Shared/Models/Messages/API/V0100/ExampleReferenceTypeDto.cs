﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module01.Shared.Models.Messages.API.V0100
{
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Messages.BaseClasses;

    public class ExampleReferenceTypeDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : TenantedRecordStateGuidIdReferenceDtoBase, IHasGuidId, IHasTenantFK, IHasRecordState
    {
    }
}
