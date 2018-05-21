using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using App.Module11.Shared.Models.Entities;
using App.Module11.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module11.Infrastructure.Initialization.ObjectMaps.Extract
{
    using App.Module11.Shared.Models.Messages.APIs.SIF.V0100;

    public class ObjectToMap_EducationProviderProfile_EducationProviderProfile : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<EducationProviderProfile, EducationProviderProfile>()
                //.BeforeMap((src, dest) => dest.AreaUnit = null)
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
                .ForMember(dest => dest.AreaUnitFK, opt =>
                {
                    opt.Condition((src, dest) => dest.AreaUnitFK != src.AreaUnitFK);// suppose dest is not null.
                    opt.MapFrom(src => src.AreaUnitFK);
                })
                .ForMember(dest => dest.AreaUnit, opt =>
                {
                    opt.Condition((src, dest) => dest.AreaUnitFK != src.AreaUnitFK);// suppose dest is not null.
                    opt.MapFrom(src => src.AreaUnit);
                })
				.ForMember(dest => dest.AuthorityTypeFK, opt =>
                {
                    opt.Condition((src, dest) => dest.AuthorityTypeFK != src.AuthorityTypeFK);// suppose dest is not null.
                    opt.MapFrom(src => src.AuthorityTypeFK);
                })
                .ForMember(dest => dest.AuthorityType, opt =>
                {
                    opt.Condition((src, dest) => dest.AuthorityTypeFK != src.AuthorityTypeFK);// suppose dest is not null.
                    opt.MapFrom(src => src.AuthorityType);
                })
                .ForMember(dest => dest.ClosedDate, opt => opt.MapFrom(s => s.ClosedDate))
				.ForMember(dest => dest.SchoolingGenderFK, opt =>
                {
                    opt.Condition((src, dest) => dest.SchoolingGenderFK != src.SchoolingGenderFK);// suppose dest is not null.
                    opt.MapFrom(src => src.SchoolingGenderFK);
                })
                .ForMember(dest => dest.SchoolingGender, opt =>
                {
                    opt.Condition((src, dest) => dest.SchoolingGenderFK != src.SchoolingGenderFK);// suppose dest is not null.
                    opt.MapFrom(src => src.SchoolingGender);
                })
                .ForMember(dest => dest.CohortEntryCurrent, opt => opt.MapFrom(s => s.CohortEntryCurrent))
                .ForMember(dest => dest.CohortEntryFuture, opt => opt.MapFrom(s => s.CohortEntryFuture))
                .ForMember(dest => dest.CohortEntryFutureFrom, opt => opt.MapFrom(s => s.CohortEntryFutureFrom))
				.ForMember(dest => dest.CoLFK, opt =>
                {
                    opt.Condition((src, dest) => dest.CoLFK != src.CoLFK);// suppose dest is not null.
                    opt.MapFrom(src => src.CoLFK);
                })
                .ForMember(dest => dest.CoL, opt =>
                {
                    opt.Condition((src, dest) => dest.CoLFK != src.CoLFK);// suppose dest is not null.
                    opt.MapFrom(src => src.CoL);
                })
				.ForMember(dest => dest.CommunityBoardFK, opt =>
                {
                    opt.Condition((src, dest) => dest.CommunityBoardFK != src.CommunityBoardFK);// suppose dest is not null.
                    opt.MapFrom(src => src.CommunityBoardFK);
                })
                .ForMember(dest => dest.CommunityBoard, opt =>
                {
                    opt.Condition((src, dest) => dest.CommunityBoardFK != src.CommunityBoardFK);// suppose dest is not null.
                    opt.MapFrom(src => src.CommunityBoard);
                })
                .ForMember(dest => dest.Contact1Name, opt => opt.MapFrom(s => s.Contact1Name))
                .ForMember(dest => dest.Contact1Role, opt => opt.MapFrom(s => s.Contact1Role))
                .ForMember(dest => dest.Contact2Name, opt => opt.MapFrom(s => s.Contact2Name))
                .ForMember(dest => dest.Contact2Role, opt => opt.MapFrom(s => s.Contact2Role))
                .ForMember(dest => dest.Decile, opt => opt.MapFrom(s => s.Decile))
				.ForMember(dest => dest.RegionFK, opt =>
                {
                    opt.Condition((src, dest) => dest.RegionFK != src.RegionFK);// suppose dest is not null.
                    opt.MapFrom(src => src.RegionFK);
                })
                .ForMember(dest => dest.Region, opt =>
                {
                    opt.Condition((src, dest) => dest.RegionFK != src.RegionFK);// suppose dest is not null.
                    opt.MapFrom(src => src.Region);
                })
                .ForMember(dest => dest.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(dest => dest.Fax, opt => opt.MapFrom(s => s.Fax))
				.ForMember(dest => dest.GeneralElectorateFK, opt =>
                {
                    opt.Condition((src, dest) => dest.GeneralElectorateFK != src.GeneralElectorateFK);// suppose dest is not null.
                    opt.MapFrom(src => src.GeneralElectorateFK);
                })
                .ForMember(dest => dest.GeneralElectorate, opt =>
                {
                    opt.Condition((src, dest) => dest.GeneralElectorateFK != src.GeneralElectorateFK);// suppose dest is not null.
                    opt.MapFrom(src => src.GeneralElectorate);
                })
				.ForMember(dest => dest.LocalOfficeFK, opt =>
                {
                    opt.Condition((src, dest) => dest.LocalOfficeFK != src.LocalOfficeFK);// suppose dest is not null.
                    opt.MapFrom(src => src.LocalOfficeFK);
                })
                .ForMember(dest => dest.LocalOffice, opt =>
                {
                    opt.Condition((src, dest) => dest.LocalOfficeFK != src.LocalOfficeFK);// suppose dest is not null.
                    opt.MapFrom(src => src.LocalOffice);
                })
				.ForMember(dest => dest.MaoriElectorateFK, opt =>
                {
                    opt.Condition((src, dest) => dest.MaoriElectorateFK != src.MaoriElectorateFK);// suppose dest is not null.
                    opt.MapFrom(src => src.MaoriElectorateFK);
                })
                .ForMember(dest => dest.MaoriElectorate, opt =>
                {
                    opt.Condition((src, dest) => dest.MaoriElectorateFK != src.MaoriElectorateFK);// suppose dest is not null.
                    opt.MapFrom(src => src.MaoriElectorate);
                })
                .ForMember(dest => dest.OpeningDate, opt => opt.MapFrom(s => s.OpeningDate))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.Name))
				.ForMember(dest => dest.StatusFK, opt =>
                {
                    opt.Condition((src, dest) => dest.StatusFK != src.StatusFK);// suppose dest is not null.
                    opt.MapFrom(src => src.StatusFK);
                })
                .ForMember(dest => dest.Status, opt =>
                {
                    opt.Condition((src, dest) => dest.StatusFK != src.StatusFK);// suppose dest is not null.
                    opt.MapFrom(src => src.Status);
                })
				.ForMember(dest => dest.ClassificationFK, opt =>
                {
                    opt.Condition((src, dest) => dest.ClassificationFK != src.ClassificationFK);// suppose dest is not null.
                    opt.MapFrom(src => src.ClassificationFK);
                })
                .ForMember(dest => dest.Classification, opt =>
                {
                    opt.Condition((src, dest) => dest.ClassificationFK != src.ClassificationFK);// suppose dest is not null.
                    opt.MapFrom(src => src.Classification);
                })
				.ForMember(dest => dest.RegionalCouncilFK, opt =>
                {
                    opt.Condition((src, dest) => dest.RegionalCouncilFK != src.RegionalCouncilFK);// suppose dest is not null.
                    opt.MapFrom(src => src.RegionalCouncilFK);
                })
                .ForMember(dest => dest.RegionalCouncil, opt =>
                {
                    opt.Condition((src, dest) => dest.RegionalCouncilFK != src.RegionalCouncilFK);// suppose dest is not null.
                    opt.MapFrom(src => src.RegionalCouncil);
                })
				.ForMember(dest => dest.EducationProviderTypeFK, opt =>
                {
                    opt.Condition((src, dest) => dest.EducationProviderTypeFK != src.EducationProviderTypeFK);// suppose dest is not null.
                    opt.MapFrom(src => src.EducationProviderTypeFK);
                })
                .ForMember(dest => dest.EducationProviderType, opt =>
                {
                    opt.Condition((src, dest) => dest.EducationProviderTypeFK != src.EducationProviderTypeFK);// suppose dest is not null.
                    opt.MapFrom(src => src.EducationProviderType);
                })
                .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(s => s.SchoolId))
				.ForMember(dest => dest.SpecialSchoolingFK, opt =>
                {
                    opt.Condition((src, dest) => dest.SpecialSchoolingFK != src.SpecialSchoolingFK);// suppose dest is not null.
                    opt.MapFrom(src => src.SpecialSchoolingFK);
                })
                .ForMember(dest => dest.SpecialSchooling, opt =>
                {
                    opt.Condition((src, dest) => dest.SpecialSchoolingFK != src.SpecialSchoolingFK);// suppose dest is not null.
                    opt.MapFrom(src => src.SpecialSchooling);
                })
				.ForMember(dest => dest.TeacherEducationFK, opt =>
                {
                    opt.Condition((src, dest) => dest.TeacherEducationFK != src.TeacherEducationFK);// suppose dest is not null.
                    opt.MapFrom(src => src.TeacherEducationFK);
                })
                .ForMember(dest => dest.TeacherEducation, opt =>
                {
                    opt.Condition((src, dest) => dest.TeacherEducationFK != src.TeacherEducationFK);// suppose dest is not null.
                    opt.MapFrom(src => src.TeacherEducation);
                })

                .ForMember(dest => dest.Telephone, opt => opt.MapFrom(s => s.Telephone))
				.ForMember(dest => dest.TerritorialAuthorityFK, opt =>
                {
                    opt.Condition((src, dest) => dest.TerritorialAuthorityFK != src.TerritorialAuthorityFK);// suppose dest is not null.
                    opt.MapFrom(src => src.TerritorialAuthorityFK);
                })
                .ForMember(dest => dest.TerritorialAuthority, opt =>
                {
                    opt.Condition((src, dest) => dest.TerritorialAuthorityFK != src.TerritorialAuthorityFK);// suppose dest is not null.
                    opt.MapFrom(src => src.TerritorialAuthority);
                })
				.ForMember(dest => dest.UrbanAreaFK, opt =>
                {
                    opt.Condition((src, dest) => dest.UrbanAreaFK != src.UrbanAreaFK);// suppose dest is not null.
                    opt.MapFrom(src => src.UrbanAreaFK);
                })
                .ForMember(dest => dest.UrbanArea, opt =>
                {
                    opt.Condition((src, dest) => dest.UrbanAreaFK != src.UrbanAreaFK);// suppose dest is not null.
                    opt.MapFrom(src => src.UrbanArea);
                })
                .ForMember(dest => dest.Url, opt => opt.MapFrom(s => s.Url))
				.ForMember(dest => dest.WardFK, opt =>
                {
                    opt.Condition((src, dest) => dest.WardFK != src.WardFK);// suppose dest is not null.
                    opt.MapFrom(src => src.WardFK);
                })
                .ForMember(dest => dest.Ward, opt =>
                {
                    opt.Condition((src, dest) => dest.WardFK != src.WardFK);// suppose dest is not null.
                    opt.MapFrom(src => src.Ward);
                })
                
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

                .ForMember(dest => dest.Locations, opt => opt.MapFrom(s => s.Locations)) //
                .ForMember(dest => dest.LevelGender, opt => opt.MapFrom(s => s.LevelGender))
                .ForMember(dest => dest.RollCounts, opt => opt.MapFrom(s => s.RollCounts))
                .AfterMap((src, dest) => dest.Locations = (dest.Locations != null && dest.Locations.Any()) ? dest.Locations : null)
                .AfterMap((src, dest) => dest.LevelGender = (dest.LevelGender != null && dest.LevelGender.Any()) ? dest.LevelGender : null)
                .AfterMap((src, dest) => dest.RollCounts = (dest.RollCounts != null && dest.RollCounts.Any()) ? dest.RollCounts : null)
            ;

            /*				                .ForMember(dest => dest.Address1City, opt => opt.Ignore())
                .ForMember(dest => dest.Address1Line1, opt => opt.Ignore())
                .ForMember(dest => dest.Address1Line2, opt => opt.Ignore())
                .ForMember(dest => dest.Address1Line3, opt => opt.Ignore())
                .ForMember(dest => dest.Address1PostalCode, opt => opt.Ignore())
                .ForMember(dest => dest.Address1Suburb, opt => opt.Ignore())
                .ForMember(dest => dest.Address2City, opt => opt.Ignore())
                .ForMember(dest => dest.Address2Line1, opt => opt.Ignore())
                .ForMember(dest => dest.Address2Line2, opt => opt.Ignore())
                .ForMember(dest => dest.Address2Line3, opt => opt.Ignore())
                .ForMember(dest => dest.Address2PostalCode, opt => opt.Ignore())
                .ForMember(dest => dest.Address2Suburb, opt => opt.Ignore())
                .ForMember(dest => dest.AreaUnitFK, opt => opt.Ignore())  
                .ForMember(dest => dest.AreaUnit, opt => opt.Ignore())//
                .ForMember(dest => dest.AuthorityTypeFK, opt => opt.Ignore()) 
                .ForMember(dest => dest.AuthorityType, opt => opt.Ignore())//
                .ForMember(dest => dest.ClosedDate, opt => opt.Ignore())
                .ForMember(dest => dest.SchoolingGenderFK, opt => opt.Ignore()) 
                .ForMember(dest => dest.SchoolingGender, opt => opt.Ignore())//
                .ForMember(dest => dest.CohortEntryCurrent, opt => opt.Ignore())
                .ForMember(dest => dest.CohortEntryFuture, opt => opt.Ignore())
                .ForMember(dest => dest.CohortEntryFutureFrom, opt => opt.Ignore())
                .ForMember(dest => dest.CoLFK, opt => opt.Ignore()) 
                .ForMember(dest => dest.CoL, opt => opt.Ignore())
                .ForMember(dest => dest.CommunityBoardFK, opt => opt.Ignore()) 
                .ForMember(dest => dest.CommunityBoard, opt => opt.Ignore())//
                .ForMember(dest => dest.Contact1Name, opt => opt.Ignore())
                .ForMember(dest => dest.Contact1Role, opt => opt.Ignore())
                .ForMember(dest => dest.Contact2Name, opt => opt.Ignore())
                .ForMember(dest => dest.Contact2Role, opt => opt.Ignore())
                .ForMember(dest => dest.Decile, opt => opt.Ignore())
                .ForMember(dest => dest.RegionFK, opt => opt.Ignore()) //
                .ForMember(dest => dest.Region, opt => opt.Ignore()) //
                .ForMember(dest => dest.Email, opt => opt.Ignore())
                .ForMember(dest => dest.Fax, opt => opt.Ignore())
                .ForMember(dest => dest.GeneralElectorateFK, opt => opt.Ignore()) //
                .ForMember(dest => dest.GeneralElectorate, opt => opt.Ignore()) //
                .ForMember(dest => dest.LocalOfficeFK, opt => opt.Ignore())//
                .ForMember(dest => dest.LocalOffice, opt => opt.Ignore()) //
                .ForMember(dest => dest.MaoriElectorateFK, opt => opt.Ignore()) //
                .ForMember(dest => dest.MaoriElectorate, opt => opt.Ignore())//
                .ForMember(dest => dest.OpeningDate, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.StatusFK, opt => opt.Ignore()) //
                .ForMember(dest => dest.Status, opt => opt.Ignore()) //
                .ForMember(dest => dest.ClassificationFK, opt => opt.Ignore()) //
                .ForMember(dest => dest.Classification, opt => opt.Ignore()) //
                .ForMember(dest => dest.RegionalCouncilFK, opt => opt.Ignore()) //
                .ForMember(dest => dest.RegionalCouncil, opt => opt.Ignore()) //
                .ForMember(dest => dest.EducationProviderTypeFK, opt => opt.Ignore()) //)
                .ForMember(dest => dest.EducationProviderType, opt => opt.Ignore()) //
                .ForMember(dest => dest.SchoolId, opt => opt.Ignore())
                .ForMember(dest => dest.SpecialSchoolingFK, opt => opt.Ignore()) //
                .ForMember(dest => dest.SpecialSchooling, opt => opt.Ignore())  //
                .ForMember(dest => dest.TeacherEducationFK, opt => opt.Ignore()) 
                .ForMember(dest => dest.TeacherEducation, opt => opt.Ignore()) //
                .ForMember(dest => dest.Telephone, opt => opt.Ignore())
                .ForMember(dest => dest.TerritorialAuthorityFK, opt => opt.Ignore()) //.ForMember(dest => dest.TerritorialAuthorityFK, opt => opt.MapFrom(s => s.TerritorialAuthorityCode))
                .ForMember(dest => dest.TerritorialAuthority, opt => opt.Ignore()) //
                .ForMember(dest => dest.UrbanAreaFK, opt => opt.Ignore())//.ForMember(dest => dest.UrbanAreaFK, opt => opt.MapFrom(s => s.UrbanAreaCode))
                .ForMember(dest => dest.UrbanArea, opt => opt.Ignore()) //
                .ForMember(dest => dest.Url, opt => opt.Ignore())
                .ForMember(dest => dest.WardFK, opt => opt.Ignore()) //.ForMember(dest => dest.WardFK, opt => opt.MapFrom(s => s.WardCode))
                .ForMember(dest => dest.Ward, opt => opt.Ignore()) //
                
                .ForMember(dest => dest.SourceSystemKey, opt => opt.Ignore())
                .ForMember(dest => dest.SourceSystemName, opt => opt.Ignore())

                .ForMember(dest => dest.CreatedByPrincipalId, opt => opt.MapFrom(s => s.CreatedByPrincipalId))
                .ForMember(dest => dest.CreatedOnUtc, opt => opt.MapFrom(s => s.CreatedOnUtc))
                .ForMember(dest => dest.DeletedByPrincipalId, opt => opt.MapFrom(s => s.DeletedByPrincipalId))
                .ForMember(dest => dest.DeletedOnUtc, opt => opt.MapFrom(s => s.DeletedOnUtc))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dest => dest.LastModifiedByPrincipalId, opt => opt.MapFrom(s => s.LastModifiedByPrincipalId))
                .ForMember(dest => dest.LastModifiedOnUtc, opt => opt.MapFrom(s => s.LastModifiedOnUtc))
                .ForMember(dest => dest.RecordState, opt => opt.MapFrom(s => s.RecordState))
                .ForMember(dest => dest.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(s => s.Timestamp))

                .ForMember(dest => dest.Locations, opt => opt.Ignore()) //
                .ForMember(dest => dest.LevelGender, opt => opt.Ignore())
                .ForMember(dest => dest.RollCounts, opt => opt.Ignore())
                .AfterMap((src, dest) => dest.Locations = (dest.Locations != null && dest.Locations.Any()) ? dest.Locations : null)
                .AfterMap((src, dest) => dest.LevelGender = (dest.LevelGender != null && dest.LevelGender.Any()) ? dest.LevelGender : null)
                .AfterMap((src, dest) => dest.RollCounts = (dest.RollCounts != null && dest.RollCounts.Any()) ? dest.RollCounts : null)*/
        }
    }
}
