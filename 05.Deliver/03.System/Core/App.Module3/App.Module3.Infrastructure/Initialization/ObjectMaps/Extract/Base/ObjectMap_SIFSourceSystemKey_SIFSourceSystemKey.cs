using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Extract.Base
{
    public class ObjectMap_SIFSourceSystemKey_SIFSourceSystemKey : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase, SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase>()
                .Include<EducationProviderStatus, EducationProviderStatus>()
                .Include<EducationProviderType, EducationProviderType>()
                .Include<Region, Region>()
                .Include<EducationProviderClassification, EducationProviderClassification>()
                .Include<EducationProviderGender, EducationProviderGender>()
                .Include<EducationProviderYearLevel, EducationProviderYearLevel>()
                .Include<AreaUnit, AreaUnit>()
                .Include<AuthorityType, AuthorityType>()
                .Include<CommunityBoard, CommunityBoard>()
                .Include<GeneralElectorate, GeneralElectorate>()
                .Include<MaoriElectorate, MaoriElectorate>()
                .Include<RegionalCouncil, RegionalCouncil>()
                .Include<RelationshipType, RelationshipType>()
                .Include<SpecialSchooling, SpecialSchooling>()
                .Include<TeacherEducation, TeacherEducation>()
                .Include<TerritorialAuthority, TerritorialAuthority>()
                .Include<UrbanArea, UrbanArea>()
                .Include<Ward, Ward>()
                .ForMember(dest => dest.SIFKey, opt => opt.MapFrom(s => s.SIFKey))
                .ForMember(dest => dest.SourceSystemKey, opt => opt.MapFrom(s => s.SourceSystemKey))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(s => s.Text))
                .ForMember(dest => dest.SourceSystemName, opt => opt.MapFrom(s => s.SourceSystemName))

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
                .ForMember(dest => dest.TenantFK, opt => opt.Ignore())
                .ForMember(dest => dest.Timestamp, opt => opt.Ignore())
                

              

                ;
        }
    }
}
