using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using App.Module32.Shared.Models.Entities;
using App.Module32.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module32.Infrastructure.Initialization.ObjectMaps.Extract
{
    /// <summary>
    /// <seealso cref="App.Module32.Infrastructure.Initialization.ObjectMaps.Extract.Base.ObjectMap_BaseMessage_TenantFKTimestampedAuditedRecordStatedGuidIdEntityBase"/>
    /// </summary>
    public class ObjectMap_SchoolProfile_EducationSchoolProfile : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<SchoolProfile, EducationSchoolProfile>()
                    .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(src => src.SchoolId)) 
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.OrgName)) 
                ;

        }
    }
}
