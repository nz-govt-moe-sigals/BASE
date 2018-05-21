using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using App.Module11.Shared.Models.Entities;
using AutoMapper;

namespace App.Module11.Infrastructure.Initialization.ObjectMaps.Extract
{
    public class ObjectToMap_EducationProviderLocation_EducationProviderLocation : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<EducationProviderLocation, EducationProviderLocation>()
                .ForMember(dest => dest.Altitude, opt => opt.MapFrom(s => s.Altitude))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(s => s.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(s => s.Longitude))
                .ForMember(dest => dest.EducationProviderFK, opt => opt.MapFrom(s => s.EducationProviderFK)) // .ForMember(dest => dest.EducationProviderFK, opt => opt.MapFrom(s => s.InstitutionNumber))


                .ForMember(dest => dest.SourceSystemKey, opt => opt.MapFrom(s => s.SourceSystemKey))
                .ForMember(dest => dest.SourceSystemName, opt => opt.MapFrom(s => s.SourceSystemName))

                .ForMember(dest => dest.CreatedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOnUtc, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedOnUtc, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedOnUtc, opt => opt.Ignore())
                .ForMember(dest => dest.RecordState, opt => opt.Ignore())
                .ForMember(dest => dest.TenantFK, opt => opt.Ignore())
                .ForMember(dest => dest.Timestamp, opt => opt.Ignore())
                ;
        }
    }
}
