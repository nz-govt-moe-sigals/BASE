using App.Core.Infrastructure.Initialization.ObjectMaps;
using App.Core.Shared.Models.Entities;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Extract.Base
{
    public class ObjectMap_BaseMessage_TenantFKTimestampedAuditedRecordStatedGuidIdEntityBase : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<BaseMessage, TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase>()
                .Include<SchoolEnrol, EducationProviderEnrolmentCount>()
                .Include<SchoolLevelGender, EducationProviderLevelGender>()
                .Include<SchoolProfile, EducationProviderProfile>()
                .Include<SchoolWGS, EducationProviderLocation>()
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
