using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using App.Module31.Shared.Models.Entities;
using App.Module31.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module31.Infrastructure.Initialization.ObjectMaps.Extract
{

    public class ObjectToMap_EducationProviderProfile_EducationProviderProfile : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<EducationProviderProfile, EducationProviderProfile>()
                //.BeforeMap((src, dest) => dest.AreaUnit = null)
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
            ;
            MapSystem(mappingExpression);
            MapTenancy(mappingExpression);
            MapCohort(mappingExpression);
            MapSchoolDetails(mappingExpression);
            MapRegionsAndElectorate(mappingExpression);
            MapSchoolingAndCommunityBoardAndTeacherEducation(mappingExpression);
            MapAreaAndAuthority(mappingExpression);
            MapCollections(mappingExpression);
            MapAddress(mappingExpression);
            MapContacts(mappingExpression);
            MapColAndWard(mappingExpression);
            MapStatusAndClassification(mappingExpression);
            AfterMap(mappingExpression);
        }

        private void MapStatusAndClassification(IMappingExpression<EducationProviderProfile, EducationProviderProfile> mappingExpression)
        {
            mappingExpression
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
                });
        }

        private void MapColAndWard(IMappingExpression<EducationProviderProfile, EducationProviderProfile> mappingExpression)
        {
            mappingExpression
                .ForMember(dest => dest.CoLFK, opt =>
                {
                    opt.Condition((src, dest) => dest.CoLFK != src.CoLFK); // suppose dest is not null.
                    opt.MapFrom(src => src.CoLFK);
                })
                .ForMember(dest => dest.CoL, opt =>
                {
                    opt.Condition((src, dest) => dest.CoLFK != src.CoLFK); // suppose dest is not null.
                    opt.MapFrom(src => src.CoL);
                })
                .ForMember(dest => dest.WardFK, opt =>
                {
                    opt.Condition((src, dest) => dest.WardFK != src.WardFK); // suppose dest is not null.
                    opt.MapFrom(src => src.WardFK);
                })
                .ForMember(dest => dest.Ward, opt =>
                {
                    opt.Condition((src, dest) => dest.WardFK != src.WardFK); // suppose dest is not null.
                    opt.MapFrom(src => src.Ward);
                });
        }

        private void MapSystem(IMappingExpression<EducationProviderProfile, EducationProviderProfile> mappingExpression)
        {
            mappingExpression
                .ForMember(dest => dest.SourceSystemKey, opt => opt.MapFrom(s => s.SourceSystemKey))
                .ForMember(dest => dest.SourceSystemName, opt => opt.MapFrom(s => s.SourceSystemName))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                ;
        }

        private void MapTenancy(IMappingExpression<EducationProviderProfile, EducationProviderProfile> mappingExpression)
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


        private void AfterMap(IMappingExpression<EducationProviderProfile, EducationProviderProfile> mappingExpression)
        {
            mappingExpression
                .AfterMap((src, dest) => dest.Locations = (dest.Locations != null && dest.Locations.Any()) ? dest.Locations : null)
                .AfterMap((src, dest) => dest.LevelGender = (dest.LevelGender != null && dest.LevelGender.Any()) ? dest.LevelGender : null)
                .AfterMap((src, dest) => dest.RollCounts = (dest.RollCounts != null && dest.RollCounts.Any()) ? dest.RollCounts : null)
                ;
        }

        private void MapCohort(IMappingExpression<EducationProviderProfile, EducationProviderProfile> mappingExpression)
        {
            mappingExpression
                .ForMember(dest => dest.CohortEntryCurrent, opt => opt.MapFrom(s => s.CohortEntryCurrent))
                .ForMember(dest => dest.CohortEntryFuture, opt => opt.MapFrom(s => s.CohortEntryFuture))
                .ForMember(dest => dest.CohortEntryFutureFrom, opt => opt.MapFrom(s => s.CohortEntryFutureFrom))
                ;
        }

        private void MapSchoolDetails(IMappingExpression<EducationProviderProfile, EducationProviderProfile> mappingExpression)
        {
            mappingExpression
                .ForMember(dest => dest.OpeningDate, opt => opt.MapFrom(s => s.OpeningDate))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(dest => dest.ClosedDate, opt => opt.MapFrom(s => s.ClosedDate))
                .ForMember(dest => dest.Decile, opt => opt.MapFrom(s => s.Decile))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(dest => dest.Fax, opt => opt.MapFrom(s => s.Fax))

                .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(s => s.SchoolId))
                .ForMember(dest => dest.Telephone, opt => opt.MapFrom(s => s.Telephone))
                .ForMember(dest => dest.Url, opt => opt.MapFrom(s => s.Url))
                ;
        }

        private void MapRegion(IMappingExpression<EducationProviderProfile, EducationProviderProfile> mappingExpression)
        {
            mappingExpression
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
                ;
        }

        private void MapElectorate(IMappingExpression<EducationProviderProfile, EducationProviderProfile> mappingExpression)
        {
            mappingExpression
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
                ;
        }

        private void MapRegionsAndElectorate(IMappingExpression<EducationProviderProfile, EducationProviderProfile> mappingExpression)
        {
            MapRegion(mappingExpression);
            MapElectorate(mappingExpression);
        }

        private void MapSchooling(IMappingExpression<EducationProviderProfile, EducationProviderProfile> mappingExpression)
        {
            mappingExpression
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
                ;
        }

        private void MapCommunityBoardAndTeacherEducation(IMappingExpression<EducationProviderProfile, EducationProviderProfile> mappingExpression)
        {
            mappingExpression
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
                ;
        }

        private void MapSchoolingAndCommunityBoardAndTeacherEducation(IMappingExpression<EducationProviderProfile, EducationProviderProfile> mappingExpression)
        {
            MapSchooling(mappingExpression);
            MapCommunityBoardAndTeacherEducation(mappingExpression);
        }

        private void MapArea(IMappingExpression<EducationProviderProfile, EducationProviderProfile> mappingExpression)
        {
            mappingExpression
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
                ;
        }

        private void MapLocalOffice(IMappingExpression<EducationProviderProfile, EducationProviderProfile> mappingExpression)
        {
            mappingExpression
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

                ;
        }


        private void MapAuthority(IMappingExpression<EducationProviderProfile, EducationProviderProfile> mappingExpression)
        {
            mappingExpression
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

                .ForMember(dest => dest.TerritorialAuthorityFK, opt =>
                {
                    opt.Condition((src, dest) => dest.TerritorialAuthorityFK != src.TerritorialAuthorityFK);// suppose dest is not null.
                    opt.MapFrom(src => src.TerritorialAuthorityFK);
                })
                .ForMember(dest => dest.TerritorialAuthority, opt =>
                {
                    opt.Condition((src, dest) => dest.TerritorialAuthorityFK != src.TerritorialAuthorityFK);// suppose dest is not null.
                    opt.MapFrom(src => src.TerritorialAuthority);
                });
        }

        private void MapAreaAndAuthority(IMappingExpression<EducationProviderProfile, EducationProviderProfile> mappingExpression)
        {
            MapArea(mappingExpression);
            MapLocalOffice(mappingExpression);
            MapAuthority(mappingExpression);
        }

        private void MapCollections(IMappingExpression<EducationProviderProfile, EducationProviderProfile> mappingExpression)
        {
            mappingExpression
                .ForMember(dest => dest.Locations, opt => opt.MapFrom(s => s.Locations)) //
                .ForMember(dest => dest.LevelGender, opt => opt.MapFrom(s => s.LevelGender))
                .ForMember(dest => dest.RollCounts, opt => opt.MapFrom(s => s.RollCounts))
                ;
        }

        private void MapContacts(IMappingExpression<EducationProviderProfile, EducationProviderProfile> mappingExpression)
        {
            mappingExpression
                .ForMember(dest => dest.Contact1Name, opt => opt.MapFrom(s => s.Contact1Name))
                .ForMember(dest => dest.Contact1Role, opt => opt.MapFrom(s => s.Contact1Role))
                .ForMember(dest => dest.Contact2Name, opt => opt.MapFrom(s => s.Contact2Name))
                .ForMember(dest => dest.Contact2Role, opt => opt.MapFrom(s => s.Contact2Role))
                ;
        }

        private void MapAddress(IMappingExpression<EducationProviderProfile, EducationProviderProfile> mappingExpression)
        {
            mappingExpression
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
                ;
        }
    }
}





