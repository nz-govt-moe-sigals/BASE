using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Extract
{
    public class ObjectToMap_EducationProviderProfile_EducationProviderProfile : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<EducationProviderProfile, EducationProviderProfile>()
                .ForMember(dest => dest.Address1City, opt => opt.MapFrom(s => s.Address1City))
                .ForMember(dest => dest.Address1Line1, opt => opt.MapFrom(s => s.Address1Line1))
                .ForMember(dest => dest.Address1Line2, opt => opt.MapFrom(s => s.Address1Line2))
                .ForMember(dest => dest.Address1Line3, opt => opt.MapFrom(s => s.Address1Line3))
                .ForMember(dest => dest.Address1PostalCode, opt => opt.MapFrom(s => s.Address1PostalCode))
                .ForMember(dest => dest.Address1Suburb, opt => opt.MapFrom(s => s.Address1Suburb))
                .ForMember(dest => dest.Address2City, opt => opt.MapFrom(s => s.Address2City))
                .ForMember(dest => dest.Address2Line1, opt => opt.MapFrom(s => s.Address2Line1))
                .ForMember(dest => dest.Address2Line2, opt => opt.MapFrom(s => s.Address2Line2))
                .ForMember(dest => dest.Address2Line3, opt => opt.MapFrom(s => s.Address2Line3))
                .ForMember(dest => dest.Address2PostalCode, opt => opt.MapFrom(s => s.Address2PostalCode))
                .ForMember(dest => dest.Address2Suburb, opt => opt.MapFrom(s => s.Address2Suburb))
                .ForMember(dest => dest.AreaUnitFK, opt => opt.MapFrom(s => s.AreaUnitFK))  
                .ForMember(dest => dest.AreaUnit, opt => opt.MapFrom(s => s.AreaUnit))//
                .ForMember(dest => dest.AuthorityTypeFK, opt => opt.MapFrom(s => s.AuthorityTypeFK)) 
                .ForMember(dest => dest.AuthorityType, opt => opt.MapFrom(s => s.AuthorityType))//
                .ForMember(dest => dest.ClosedDate, opt => opt.MapFrom(s => s.ClosedDate))
                .ForMember(dest => dest.SchoolingGenderFK, opt => opt.MapFrom(s => s.SchoolingGenderFK)) 
                .ForMember(dest => dest.SchoolingGender, opt => opt.MapFrom(s => s.SchoolingGender))//
                .ForMember(dest => dest.CohortEntryCurrent, opt => opt.MapFrom(s => s.CohortEntryCurrent))
                .ForMember(dest => dest.CohortEntryFuture, opt => opt.MapFrom(s => s.CohortEntryFuture))
                .ForMember(dest => dest.CohortEntryFutureFrom, opt => opt.MapFrom(s => s.CohortEntryFutureFrom))
                .ForMember(dest => dest.CoLFK, opt => opt.MapFrom(s => s.CoLFK)) 
                .ForMember(dest => dest.CoL, opt => opt.MapFrom(s => s.CoL))
                .ForMember(dest => dest.CommunityBoardFK, opt => opt.MapFrom(s => s.CommunityBoardFK)) 
                .ForMember(dest => dest.CommunityBoard, opt => opt.MapFrom(s => s.CommunityBoard))//
                .ForMember(dest => dest.Contact1Name, opt => opt.MapFrom(s => s.Contact1Name))
                .ForMember(dest => dest.Contact1Role, opt => opt.MapFrom(s => s.Contact1Role))
                .ForMember(dest => dest.Contact2Name, opt => opt.MapFrom(s => s.Contact2Name))
                .ForMember(dest => dest.Contact2Role, opt => opt.MapFrom(s => s.Contact2Role))
                .ForMember(dest => dest.Decile, opt => opt.MapFrom(s => s.Decile))
                .ForMember(dest => dest.RegionFK, opt => opt.MapFrom(s => s.RegionFK)) //
                .ForMember(dest => dest.Region, opt => opt.MapFrom(s => s.Region)) //
                .ForMember(dest => dest.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(dest => dest.Fax, opt => opt.MapFrom(s => s.Fax))
                .ForMember(dest => dest.GeneralElectorateFK, opt => opt.MapFrom(s => s.GeneralElectorateFK)) //
                .ForMember(dest => dest.GeneralElectorate, opt => opt.MapFrom(s => s.GeneralElectorate)) //
                .ForMember(dest => dest.LocalOfficeFK, opt => opt.MapFrom(s => s.LocalOfficeFK))//
                .ForMember(dest => dest.LocalOffice, opt => opt.MapFrom(s => s.LocalOffice)) //
                .ForMember(dest => dest.MaoriElectorateFK, opt => opt.MapFrom(s => s.MaoriElectorateFK)) //
                .ForMember(dest => dest.MaoriElectorate, opt => opt.MapFrom(s => s.MaoriElectorate))//
                .ForMember(dest => dest.OpeningDate, opt => opt.MapFrom(s => s.OpeningDate))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(dest => dest.StatusFK, opt => opt.MapFrom(s => s.StatusFK)) //
                .ForMember(dest => dest.Status, opt => opt.MapFrom(s => s.Status)) //
                .ForMember(dest => dest.TypeFK, opt => opt.MapFrom(s => s.TypeFK)) //
                .ForMember(dest => dest.Type, opt => opt.MapFrom(s => s.Type)) //
                .ForMember(dest => dest.RegionalCouncilFK, opt => opt.MapFrom(s => s.RegionalCouncilFK)) //
                .ForMember(dest => dest.RegionalCouncil, opt => opt.MapFrom(s => s.RegionalCouncil)) //
                .ForMember(dest => dest.EducationProviderTypeFK, opt => opt.MapFrom(s => s.EducationProviderTypeFK)) //)
                .ForMember(dest => dest.EducationProviderType, opt => opt.MapFrom(s => s.EducationProviderType)) //
                .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(s => s.SchoolId))
                .ForMember(dest => dest.SpecialSchoolingFK, opt => opt.MapFrom(s => s.SpecialSchoolingFK)) //
                .ForMember(dest => dest.SpecialSchooling, opt => opt.MapFrom(s => s.SpecialSchooling))  //
                .ForMember(dest => dest.TeacherEducationFK, opt => opt.MapFrom(s => s.TeacherEducationFK)) 
                .ForMember(dest => dest.TeacherEducation, opt => opt.MapFrom(s => s.TeacherEducation)) //
                .ForMember(dest => dest.Telephone, opt => opt.MapFrom(s => s.Telephone))
                .ForMember(dest => dest.TerritorialAuthorityFK, opt => opt.MapFrom(s => s.TerritorialAuthorityFK)) //.ForMember(dest => dest.TerritorialAuthorityFK, opt => opt.MapFrom(s => s.TerritorialAuthorityCode))
                .ForMember(dest => dest.TerritorialAuthority, opt => opt.MapFrom(s => s.TerritorialAuthority)) //
                .ForMember(dest => dest.UrbanAreaFK, opt => opt.MapFrom(s => s.UrbanAreaFK))//.ForMember(dest => dest.UrbanAreaFK, opt => opt.MapFrom(s => s.UrbanAreaCode))
                .ForMember(dest => dest.UrbanArea, opt => opt.MapFrom(s => s.UrbanArea)) //
                .ForMember(dest => dest.Url, opt => opt.MapFrom(s => s.Url))
                .ForMember(dest => dest.WardFK, opt => opt.MapFrom(s => s.WardFK)) //.ForMember(dest => dest.WardFK, opt => opt.MapFrom(s => s.WardCode))
                .ForMember(dest => dest.Ward, opt => opt.MapFrom(s => s.Ward)) //
                .ForMember(dest => dest.SourceSystemKey, opt => opt.MapFrom(s => s.SourceSystemKey))
                .ForMember(dest => dest.SourceSystemName, opt => opt.MapFrom(s => s.SourceSystemName))

                .ForMember(dest => dest.CreatedByPrincipalId, opt => opt.UseDestinationValue())
                .ForMember(dest => dest.CreatedOnUtc, opt => opt.UseDestinationValue())
                .ForMember(dest => dest.DeletedByPrincipalId, opt => opt.UseDestinationValue())
                .ForMember(dest => dest.DeletedOnUtc, opt => opt.UseDestinationValue())
                .ForMember(dest => dest.Id, opt => opt.UseDestinationValue())
                .ForMember(dest => dest.LastModifiedByPrincipalId, opt => opt.UseDestinationValue())
                .ForMember(dest => dest.LastModifiedOnUtc, opt => opt.UseDestinationValue())
                .ForMember(dest => dest.RecordState, opt => opt.UseDestinationValue())
                .ForMember(dest => dest.TenantFK, opt => opt.UseDestinationValue())
                .ForMember(dest => dest.Timestamp, opt => opt.UseDestinationValue())
                ;
        }
    }
}
