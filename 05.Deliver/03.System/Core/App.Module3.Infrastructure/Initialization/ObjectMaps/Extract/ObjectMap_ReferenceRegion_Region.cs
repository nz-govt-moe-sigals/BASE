using System;
using AutoMapper;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Messages.Extract;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Extract
{
    public class ObjectMap_ReferenceRegion_Region : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<ReferenceRegion, Region>();
        }
    }
}
