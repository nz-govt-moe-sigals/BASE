using System;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using AutoMapper;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Messages.Extract;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Extract
{
    public class ObjectMap_ReferenceAuthorityType_AuthorityType : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<ReferenceAuthorityType, AuthorityType>();
        }
    }
}
