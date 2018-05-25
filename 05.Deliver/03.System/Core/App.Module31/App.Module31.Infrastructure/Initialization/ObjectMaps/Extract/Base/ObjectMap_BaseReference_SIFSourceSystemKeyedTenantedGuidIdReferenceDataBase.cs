using App.Core.Infrastructure.Initialization.ObjectMaps;
using App.Module31.Shared.Models.Entities;
using App.Module31.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module31.Infrastructure.Initialization.ObjectMaps.Extract.Base
{
    public class ObjectMap_BaseReference_SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<BaseReference, SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase>()
                .ForMember(dest => dest.SIFKey, opt => opt.MapFrom(s => s.Code))
                //ensure these match ObjectMap_BaseReference_TenantedFIRSTKeyedGuidIdReferenceDataBase
                .ForMember(dest => dest.DisplayOrderHint, opt => opt.Ignore())
                .ForMember(dest => dest.DisplayStyleHint, opt => opt.Ignore())
                .ForMember(dest => dest.Enabled, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Timestamp, opt => opt.Ignore())
                .ForMember(dest => dest.SourceSystemName, opt => opt.Ignore())
                .ForMember(dest => dest.SourceSystemKey, opt => opt.MapFrom(s => s.Code))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(s => s.Description))
                //.ForMember(dest => dest.Description, opt => opt.MapFrom(s => s.Description))

                ;
            Include(mappingExpression);
            MapTenancy(mappingExpression);
        }

        private void MapTenancy(IMappingExpression<BaseReference, SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase> mappingExpression)
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

        private void Include(IMappingExpression<BaseReference, SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase> mappingExpression)
        {
            IncludeRegionAndElectorate(mappingExpression);
            mappingExpression
                .Include<ReferenceOrganisationStatus, EducationProviderStatus>()
                .Include<ReferenceOrganisationType, EducationProviderType>()
                .Include<ReferenceSchoolClassification, EducationProviderClassification>()
                .Include<ReferenceSchoolingGender, EducationProviderGender>()
                .Include<ReferenceSchoolYearLevel, EducationProviderYearLevel>()
                .Include<ReferenceAuthorityType, AuthorityType>()
                .Include<ReferenceCommunityBoard, CommunityBoard>()
                .Include<ReferenceRelationshipType, RelationshipType>()
                .Include<ReferenceSpecialSchooling, SpecialSchooling>()
                .Include<ReferenceTeacherEducation, TeacherEducation>()
                .Include<ReferenceTerritorialAuthority, TerritorialAuthority>()
                .Include<ReferenceWard, Ward>()
                ;
        }

        private void IncludeRegionAndElectorate(IMappingExpression<BaseReference, SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase> mappingExpression)
        {
            mappingExpression
                .Include<ReferenceAreaUnit, AreaUnit>()
                .Include<ReferenceRegion, Region>()
                .Include<ReferenceUrbanArea, UrbanArea>()
                .Include<ReferenceGeneralElectorate, GeneralElectorate>()
                .Include<ReferenceMaoriElectorate, MaoriElectorate>()
                .Include<ReferenceRegionalCouncil, RegionalCouncil>()
                ;
        }
    }
}





