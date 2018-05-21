using System;
using AutoMapper;
using App.Module31.Shared.Models.Entities;
using App.Module31.Shared.Models.Messages.Extract;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module31.Infrastructure.Initialization.ObjectMaps.Extract
{
    /// <summary>
    /// <seealso cref="App.Module31.Infrastructure.Initialization.ObjectMaps.Extract.Base.ObjectMap_BaseReference_SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase"/>
    /// <seealso cref="App.Module31.Infrastructure.Initialization.ObjectMaps.Extract.Base.ObjectMap_SIFSourceSystemKey_SIFSourceSystemKey"/>
    /// </summary>
    public class ObjectMap_ReferenceSchoolingGender_EducationProviderGender : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<ReferenceSchoolingGender, EducationProviderGender>();
            config.CreateMap<EducationProviderGender, EducationProviderGender>();
        }
    }
}





