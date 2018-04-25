using System;
using AutoMapper;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Messages.Extract;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Extract
{
    public class ObjectMap_SchoolProfile_EducationProviderProfile : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<SchoolProfile, EducationProviderProfile>()
                .ForMember(dest => dest.Address1City, opt => opt.MapFrom(s => s.Add1City))
                .ForMember(dest => dest.Address1Line1, opt => opt.MapFrom(s => s.Add1Line1))
                .ForMember(dest => dest.Address1Line2, opt => opt.MapFrom(s => s.Add1Line2))
                .ForMember(dest => dest.Address1Line3, opt => opt.MapFrom(s => s.Add1Line3))
                .ForMember(dest => dest.Address1PostalCode, opt => opt.MapFrom(s => s.Add1PostalCode))
                .ForMember(dest => dest.Address1Suburb, opt => opt.MapFrom(s => s.Add1Suburb))
                .ForMember(dest => dest.Address2City, opt => opt.MapFrom(s => s.Add2City))
                .ForMember(dest => dest.Address2Line1, opt => opt.MapFrom(s => s.Add2Line1))
                .ForMember(dest => dest.Address2Line2, opt => opt.MapFrom(s => s.Add2Line2))
                .ForMember(dest => dest.Address2Line3, opt => opt.MapFrom(s => s.Add2Line3))
                .ForMember(dest => dest.Address2PostalCode, opt => opt.MapFrom(s => s.Add2PostalCode))
                .ForMember(dest => dest.Address2Suburb, opt => opt.MapFrom(s => s.Add2Suburb))
                .ForMember(dest => dest.AreaUnitFK, opt => opt.Ignore()) //.ForMember(dest => dest.AreaUnitFK, opt => opt.MapFrom(s => s.AreaUnitCode))  
                .ForMember(dest => dest.AreaUnit, opt => opt.Ignore()) //
                .ForMember(dest => dest.AuthorityTypeFK, opt => opt.Ignore()) //.ForMember(dest => dest.AuthorityTypeFK, opt => opt.MapFrom(s => s.AuthorityCode))
                .ForMember(dest => dest.AuthorityType, opt => opt.Ignore()) //
                .ForMember(dest => dest.ClosedDate, opt => opt.MapFrom(s => s.ClosedDate))
                .ForMember(dest => dest.SchoolingGenderFK, opt => opt.Ignore()) //.ForMember(dest => dest.SchoolingGenderFK, opt => opt.MapFrom(s => s.CoEdStatusCode))
                .ForMember(dest => dest.SchoolingGender, opt => opt.Ignore())//
                .ForMember(dest => dest.CohortEntryCurrent, opt => opt.MapFrom(s => s.CohortEntryCurrent))
                .ForMember(dest => dest.CohortEntryFuture, opt => opt.MapFrom(s => s.CohortEntryFuture))
                .ForMember(dest => dest.CohortEntryFutureFrom, opt => opt.MapFrom(s => s.CohortEntryFutureFrom))
                .ForMember(dest => dest.CoLFK, opt => opt.Ignore()) //.ForMember(dest => dest.CoLFK, opt => opt.MapFrom(s => s.ColId))
                .ForMember(dest => dest.CoL, opt => opt.Ignore()) //.ForMember(dest => dest., opt => opt.MapFrom(s => s.ColName))
                .ForMember(dest => dest.CommunityBoardFK, opt => opt.Ignore()) //.ForMember(dest => dest.CommunityBoardFK, opt => opt.MapFrom(s => s.CommunityBoardCode))
                .ForMember(dest => dest.CommunityBoard, opt => opt.Ignore())//
                .ForMember(dest => dest.Contact1Name, opt => opt.MapFrom(s => s.Contact1Name))
                .ForMember(dest => dest.Contact1Role, opt => opt.MapFrom(s => s.Contact1Role))
                .ForMember(dest => dest.Contact2Name, opt => opt.MapFrom(s => s.Contact2Name))
                .ForMember(dest => dest.Contact2Role, opt => opt.MapFrom(s => s.Contact2Role))
                .ForMember(dest => dest.Decile, opt => opt.MapFrom(s => s.Decile))
                .ForMember(dest => dest.RegionFK, opt => opt.Ignore()) //.ForMember(dest => dest.RegionFK, opt => opt.MapFrom(s => s.EducationRegionCode))
                .ForMember(dest => dest.Region, opt => opt.Ignore()) //
                .ForMember(dest => dest.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(dest => dest.Fax, opt => opt.MapFrom(s => s.Fax))
                .ForMember(dest => dest.GeneralElectorateFK, opt => opt.Ignore()) //.ForMember(dest => dest.GeneralElectorateFK, opt => opt.MapFrom(s => s.GeneralElectorateCode))
                .ForMember(dest => dest.GeneralElectorate, opt => opt.Ignore()) //
                .ForMember(dest => dest.LocalOfficeFK, opt => opt.Ignore())//.ForMember(dest => dest.LocalOfficeFK, opt => opt.MapFrom(s => s.LocalOfficeId))
                .ForMember(dest => dest.LocalOffice, opt => opt.Ignore()) //.ForMember(dest => dest., opt => opt.MapFrom(s => s.LocalOfficeName))
                .ForMember(dest => dest.MaoriElectorateFK, opt => opt.Ignore()) //.ForMember(dest => dest.MaoriElectorateFK, opt => opt.MapFrom(s => s.MaoriElectorateCode))
                .ForMember(dest => dest.MaoriElectorate, opt => opt.Ignore())//
                .ForMember(dest => dest.OpeningDate, opt => opt.MapFrom(s => s.OpeningDate))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.OrgName))
                .ForMember(dest => dest.StatusFK, opt => opt.Ignore()) //.ForMember(dest => dest.StatusFK, opt => opt.MapFrom(s => s.OrgStatus))
                .ForMember(dest => dest.Status, opt => opt.Ignore()) //
                .ForMember(dest => dest.TypeFK, opt => opt.Ignore()) //.ForMember(dest => dest.EducationProviderTypeFK, opt => opt.MapFrom(s => s.OrgType))
                .ForMember(dest => dest.Type, opt => opt.Ignore()) //
                .ForMember(dest => dest.RegionalCouncilFK, opt => opt.Ignore()) //.ForMember(dest => dest.RegionalCouncilFK, opt => opt.MapFrom(s => s.RegionalCouncilCode))
                .ForMember(dest => dest.RegionalCouncil, opt => opt.Ignore()) //
                .ForMember(dest => dest.EducationProviderTypeFK, opt => opt.Ignore()) //.ForMember(dest => dest.EducationProviderTypeFK, opt => opt.MapFrom(s => s.SchoolClassificationCode))
                .ForMember(dest => dest.EducationProviderType, opt => opt.Ignore()) //
                .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(s => s.SchoolsId))
                .ForMember(dest => dest.SpecialSchoolingFK, opt => opt.Ignore()) //.ForMember(dest => dest.SpecialSchoolingFK, opt => opt.MapFrom(s => s.SpecialSchoolingCode))
                .ForMember(dest => dest.SpecialSchooling, opt => opt.Ignore())  //
                .ForMember(dest => dest.TeacherEducationFK, opt => opt.Ignore()) //.ForMember(dest => dest.TeacherEducationFK, opt => opt.MapFrom(s => s.TeacherEducationCode))
                .ForMember(dest => dest.TeacherEducation, opt => opt.Ignore()) //
                .ForMember(dest => dest.Telephone, opt => opt.MapFrom(s => s.Telephone))
                .ForMember(dest => dest.TerritorialAuthorityFK, opt => opt.Ignore()) //.ForMember(dest => dest.TerritorialAuthorityFK, opt => opt.MapFrom(s => s.TerritorialAuthorityCode))
                .ForMember(dest => dest.TerritorialAuthority, opt => opt.Ignore()) //
                .ForMember(dest => dest.UrbanAreaFK, opt => opt.Ignore())//.ForMember(dest => dest.UrbanAreaFK, opt => opt.MapFrom(s => s.UrbanAreaCode))
                .ForMember(dest => dest.UrbanArea, opt => opt.Ignore()) //
                .ForMember(dest => dest.Url, opt => opt.MapFrom(s => s.Url))
                .ForMember(dest => dest.WardFK, opt => opt.Ignore()) //.ForMember(dest => dest.WardFK, opt => opt.MapFrom(s => s.WardCode))
                .ForMember(dest => dest.Ward, opt => opt.Ignore()) //
                .ForMember(dest => dest.SourceSystemKey, opt => opt.MapFrom(s => s.ProfilesId))
                .ForMember(dest => dest.SourceSystemName, opt => opt.Ignore())
                ;
        }
    }
}
