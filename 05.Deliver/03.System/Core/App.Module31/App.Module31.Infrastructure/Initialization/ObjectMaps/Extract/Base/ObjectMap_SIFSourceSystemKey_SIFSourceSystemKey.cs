using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using App.Module31.Shared.Models.Entities;
using App.Module31.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module31.Infrastructure.Initialization.ObjectMaps.Extract.Base
{
    public class ObjectMap_SIFSourceSystemKey_SIFSourceSystemKey : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase, SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase>()

                .ForMember(dest => dest.SIFKey, opt => opt.MapFrom(s => s.SIFKey))
                .ForMember(dest => dest.SourceSystemKey, opt => opt.MapFrom(s => s.SourceSystemKey))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(dest => dest.SourceSystemName, opt => opt.MapFrom(s => s.SourceSystemName))

                .ForMember(dest => dest.DisplayOrderHint, opt => opt.Ignore())
                .ForMember(dest => dest.DisplayStyleHint, opt => opt.Ignore())
                .ForMember(dest => dest.Enabled, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                ;
            MapTenancy(mappingExpression);
            Include(mappingExpression);
        }

        private void MapTenancy(IMappingExpression<SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase,SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase> mappingExpression)
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

        private void Include(IMappingExpression<SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase, SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase> mappingExpression)
        {
            IncludeRegionAndElectorate(mappingExpression);
            mappingExpression
                .Include<EducationProviderStatus, EducationProviderStatus>()
                .Include<EducationProviderType, EducationProviderType>()
                .Include<EducationProviderClassification, EducationProviderClassification>()
                .Include<EducationProviderGender, EducationProviderGender>()
                .Include<EducationProviderYearLevel, EducationProviderYearLevel>()
                .Include<AuthorityType, AuthorityType>()
                .Include<CommunityBoard, CommunityBoard>()
                .Include<RelationshipType, RelationshipType>()
                .Include<SpecialSchooling, SpecialSchooling>()
                .Include<TeacherEducation, TeacherEducation>()
                .Include<TerritorialAuthority, TerritorialAuthority>()
                .Include<Ward, Ward>()
                ;
        }

        private void IncludeRegionAndElectorate(IMappingExpression<SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase, SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase> mappingExpression)
        {
            mappingExpression
                .Include<AreaUnit, AreaUnit>()
                .Include<Region, Region>()
                .Include<UrbanArea, UrbanArea>()
                .Include<GeneralElectorate, GeneralElectorate>()
                .Include<MaoriElectorate, MaoriElectorate>()
                .Include<RegionalCouncil, RegionalCouncil>()
                ;
        }
    }
}





