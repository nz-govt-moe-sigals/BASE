using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module31.Infrastructure.Initialization.ObjectMaps.Messages.SIF.V0100
{
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Module31.Shared.Models.Entities;
    using App.Module31.Shared.Models.Messages.APIs.SIF.V0100;
    using AutoMapper;

    public class ObjectMap_EducationProvider_EducationProviderDto
        : IHasAutomapperInitializer

    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            var mappingExpression =  config.CreateMap<EducationProviderProfile, SchoolDirectoryDto>()
                .ForMember(t => t.SchoolNumber, opt => opt.MapFrom(src => src.SchoolId))
                .ForMember(t => t.SchoolName, opt => opt.MapFrom(src => src.Name))
                .ForMember(t => t.SchoolType, opt => opt.MapFrom(src => src.EducationProviderType.Title))
                .ForMember(t => t.Definition, opt => opt.Ignore()) //Not sure how to Map
                .ForMember(t => t.Decile, opt => opt.MapFrom(src => src.Decile))
                ;
            MapReferenceInfo(mappingExpression);
            MapAddress(mappingExpression);
            MapContactInfo(mappingExpression);
            MapLocation(mappingExpression);
            MapCounts(mappingExpression);
        }

        private void MapReferenceInfo(IMappingExpression<EducationProviderProfile, SchoolDirectoryDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Authority, opt => opt.MapFrom(src => src.AuthorityType.Title))
                .ForMember(t => t.GenderOfStudents, opt => opt.MapFrom(src => src.SchoolingGender.Title))
                .ForMember(t => t.TerritorialAuthority, opt => opt.MapFrom(src => src.TerritorialAuthority.Title))
                .ForMember(t => t.RegionalCouncil, opt => opt.MapFrom(src => src.RegionalCouncil.Title))
                .ForMember(t => t.LocalOffice, opt => opt.MapFrom(src => src.LocalOffice.Title))
                .ForMember(t => t.EducationRegion, opt => opt.MapFrom(src => src.Region.Title))
                .ForMember(t => t.GeneralElectorate, opt => opt.MapFrom(src => src.GeneralElectorate.Title))
                .ForMember(t => t.MaoriElectorate, opt => opt.MapFrom(src => src.MaoriElectorate.Title))
                .ForMember(t => t.CensusAreaUnit, opt => opt.MapFrom(src => src.AreaUnit.Title))
                .ForMember(t => t.Ward, opt => opt.MapFrom(src => src.Ward.Title))
                .ForMember(t => t.CommunityOfLearningId, opt => opt.MapFrom(src => src.CoL.Id))
                .ForMember(t => t.CommunityOfLearningName, opt => opt.MapFrom(src => src.CoL.Title))
                ;
        }

        private void MapContactInfo(IMappingExpression<EducationProviderProfile, SchoolDirectoryDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.SchoolWebsite, opt => opt.MapFrom(src => src.Url))
                .ForMember(t => t.Telephone, opt => opt.MapFrom(src => src.Telephone))
                .ForMember(t => t.Fax, opt => opt.MapFrom(src => src.Fax))
                .ForMember(t => t.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(t => t.Principal, opt => opt.MapFrom(src => src.Contact1Name))
                ;
        }

        private void MapAddress(IMappingExpression<EducationProviderProfile, SchoolDirectoryDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Street,opt => opt.MapFrom(src => src.Address1Line1 + " " + src.Address1Line2 + " " + src.Address1Line3))
                .ForMember(t => t.Suburb, opt => opt.MapFrom(src => src.Address1Suburb))
                .ForMember(t => t.City, opt => opt.MapFrom(src => src.Address1City))
                .ForMember(t => t.PostalAddress1, opt => opt.MapFrom(src => src.Address2Line1))
                .ForMember(t => t.PostalAddress2, opt => opt.MapFrom(src => src.Address2Line2))
                .ForMember(t => t.PostalAddress3, opt => opt.MapFrom(src => src.Address2Line3))
                .ForMember(t => t.PostCode, opt => opt.MapFrom(src => src.Address2PostalCode))
                .ForMember(t => t.UrbanArea, opt => opt.MapFrom(src => src.UrbanArea.Title))
                ;
        }

        public void MapLocation(IMappingExpression<EducationProviderProfile, SchoolDirectoryDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Longitude, opt => opt.MapFrom(src => src.Locations.OrderByDescending(x => x.LastModifiedOnUtc).FirstOrDefault().Longitude))
                .ForMember(t => t.Latitude, opt => opt.MapFrom(src => src.Locations.OrderByDescending(x => x.LastModifiedOnUtc).FirstOrDefault().Latitude))
                ;
        }

        public void MapCounts(IMappingExpression<EducationProviderProfile, SchoolDirectoryDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.TotalSchoolRole, opt => opt.MapFrom(src => src.RollCounts.OrderByDescending(x => x.Date).FirstOrDefault().TotalRoll))
                .ForMember(t => t.EuropeanPakeha, opt => opt.MapFrom(src => src.RollCounts.OrderByDescending(x => x.Date).FirstOrDefault().European))
                .ForMember(t => t.Maori, opt => opt.MapFrom(src => src.RollCounts.OrderByDescending(x => x.Date).FirstOrDefault().Maori))
                .ForMember(t => t.Pasifika, opt => opt.MapFrom(src => src.RollCounts.OrderByDescending(x => x.Date).FirstOrDefault().Pasifika))
                .ForMember(t => t.Asian, opt => opt.MapFrom(src => src.RollCounts.OrderByDescending(x => x.Date).FirstOrDefault().Asian))
                .ForMember(t => t.MELAA, opt => opt.MapFrom(src => src.RollCounts.OrderByDescending(x => x.Date).FirstOrDefault().MELAA))
                .ForMember(t => t.Other, opt => opt.MapFrom(src => src.RollCounts.OrderByDescending(x => x.Date).FirstOrDefault().Other))
                .ForMember(t => t.International, opt => opt.MapFrom(src => src.RollCounts.OrderByDescending(x => x.Date).FirstOrDefault().International))
                ;
        }
    }
}





