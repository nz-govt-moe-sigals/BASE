using App.Core.Infrastructure.Initialization.ObjectMaps;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Messages.Extract;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Extract
{
    /// <summary>
    /// <seealso cref="App.Module3.Infrastructure.Initialization.ObjectMaps.Extract.Base.ObjectMap_BaseReference_SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase"/>
    /// <seealso cref="App.Module3.Infrastructure.Initialization.ObjectMaps.Extract.Base.ObjectMap_SIFSourceSystemKey_SIFSourceSystemKey"/>
    /// </summary>
    public class ObjectMap_ReferenceAreaUnit_AreaUnit : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<ReferenceAreaUnit, AreaUnit>();
            config.CreateMap<AreaUnit, AreaUnit>();
        }
    }
}
