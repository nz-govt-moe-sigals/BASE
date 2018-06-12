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
    public class ObjectMap_EducationSchoolProfile_EducationSchoolProfile : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<EducationSchoolProfile, EducationSchoolProfile>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.SourceModifiedDate, opt => opt.MapFrom(src => src.SourceModifiedDate))
                    .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(src => src.SchoolId))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                ;
            MapTenancy(mappingExpression);
        }


        private void MapTenancy(IMappingExpression<EducationSchoolProfile, EducationSchoolProfile> mappingExpression)
        {
            mappingExpression
                .ForMember(dest => dest.CreatedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOnUtc, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedOnUtc, opt => opt.Ignore())

                .ForMember(dest => dest.LastModifiedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedOnUtc, opt => opt.Ignore())
                .ForMember(dest => dest.RecordState, opt => opt.Ignore())
                .ForMember(dest => dest.TenantFK, opt => opt.Ignore())
                .ForMember(dest => dest.Timestamp, opt => opt.Ignore())
                ;
        }
    }
}
