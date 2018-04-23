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
    public class ObjectMap_BaseReference_TenantedFIRSTSIFKeyedGuidIdReferenceDataBase : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<BaseReference, TenantedSourceKeySIFKeyedGuidIdReferenceDataBase>()
                .Include<ReferenceAreaUnit, AreaUnit>()
                .Include<ReferenceAuthorityType, AuthorityType>()
                .Include<ReferenceCommunityBoard, CommunityBoard>()
                .Include<ReferenceGeneralElectorate, GeneralElectorate>()
                .Include<ReferenceMaoriElectorate, MaoriElectorate>()
                .Include<ReferenceOrganisationStatus, EducationProviderStatus>()
                .Include<ReferenceOrganisationType, EducationProviderType>()
                .Include<ReferenceRegion, Region>()
                .Include<ReferenceRegionalCouncil, RegionalCouncil>()
                .Include<ReferenceRelationshipType, RelationshipType>()
                .Include<ReferenceSchoolClassification, EducationProviderClassification>()
                .Include<ReferenceSchoolingGender, EducationProviderGender>()
                .Include<ReferenceSchoolYearLevel, EducationProviderYearLevel>()
                .Include<ReferenceSpecialSchooling, SpecialSchooling>()
                .Include<ReferenceTeacherEducation, TeacherEducation>()
                .Include<ReferenceTerritorialAuthority, TerritorialAuthority>()
                .Include<ReferenceUrbanArea, UrbanArea>()
                .Include<ReferenceWard, Ward>()
                .ForMember(dest => dest.CreatedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOnUtc, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedOnUtc, opt => opt.Ignore())
                .ForMember(dest => dest.DisplayOrderHint, opt => opt.Ignore())
                .ForMember(dest => dest.DisplayStyleHint, opt => opt.Ignore())
                .ForMember(dest => dest.Enabled, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedOnUtc, opt => opt.Ignore())
                .ForMember(dest => dest.RecordState, opt => opt.Ignore())
                .ForMember(dest => dest.SIFKey, opt => opt.Ignore())
                .ForMember(dest => dest.TenantFK, opt => opt.Ignore())
                .ForMember(dest => dest.Timestamp, opt => opt.Ignore())
                .ForMember(dest => dest.SourceSystemKey, opt => opt.MapFrom(s => s.Code))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(s => s.Description))
                ;
        }
    }
}
