using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Messages.SIF.V0100
{
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Module3.Shared.Models.Entities;
    using App.Module3.Shared.Models.Messages.APIs.SIF.V0100;
    using AutoMapper;

    public class ObjectMap_EducationProvider_EducationProviderDto
        : IHasAutomapperInitializer

    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<EducationProviderProfile, EducationProviderDto>()


                .ForMember(t => t.Address1Line1, opt => opt.MapFrom(s => s.Address1Line1))
                .ForMember(t => t.Address1Line2, opt => opt.MapFrom(s => s.Address1Line2))
                .ForMember(t => t.Address1Line3, opt => opt.MapFrom(s => s.Address1Line3))
                .ForMember(t => t.Address1City, opt => opt.MapFrom(s => s.Address1City))
                .ForMember(t => t.Address1Suburb, opt => opt.MapFrom(s => s.Address1Suburb))
                .ForMember(t => t.Address1PostalCode, opt => opt.MapFrom(s => s.Address1PostalCode))

                .ForMember(t => t.ClosedDate, opt => opt.MapFrom(s => s.ClosedDate))
                .ForMember(t => t.OpeningDate, opt => opt.MapFrom(s => s.OpeningDate))

                .ForMember(t => t.CohortEntryCurrent, opt => opt.MapFrom(s => s.CohortEntryCurrent))
                .ForMember(t => t.CohortEntryFuture, opt => opt.MapFrom(s => s.CohortEntryFuture))


                .ForMember(t => t.Contact1Name, opt => opt.MapFrom(s => s.Contact1Name))
                .ForMember(t => t.Contact1Role, opt => opt.MapFrom(s => s.Contact1Role))

                .ForMember(t => t.Contact2Name, opt => opt.MapFrom(s => s.Contact2Name))
                .ForMember(t => t.Contact2Role, opt => opt.MapFrom(s => s.Contact2Role))

                .ForMember(t => t.Decile, opt => opt.MapFrom(s => s.Decile))

                .ForMember(t => t.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(t => t.Fax, opt => opt.MapFrom(s => s.Fax))

                //--------

                .ForMember(t => t.LevelGender, opt => opt.MapFrom(s => s.LevelGender))
                .ForMember(t => t.RollCounts, opt => opt.MapFrom(s => s.RollCounts))

                //--------
                //Reference:

                .ForMember(t => t.AreaUnit, opt => opt.MapFrom(s => s.AreaUnit))
                .ForMember(t => t.AuthorityType, opt => opt.MapFrom(s => s.AuthorityType))
                .ForMember(t => t.Classification, opt => opt.MapFrom(s => s.Classification))
                .ForMember(t => t.CoL, opt => opt.MapFrom(s => s.CoL))
                .ForMember(t => t.CommunityBoard, opt => opt.MapFrom(s => s.CommunityBoard))
                .ForMember(t => t.EducationProviderType, opt => opt.MapFrom(s => s.EducationProviderType))
                .ForMember(t => t.GeneralElectorate, opt => opt.MapFrom(s => s.GeneralElectorate))
                .ForMember(t => t.LocalOffice, opt => opt.MapFrom(s => s.LocalOffice))
                .ForMember(t => t.MaoriElectorate, opt => opt.MapFrom(s => s.MaoriElectorate))
                .ForMember(t => t.EducationProviderType, opt => opt.MapFrom(s => s.EducationProviderType))
                .ForMember(t => t.Region, opt => opt.MapFrom(s => s.Region))
                .ForMember(t => t.RegionalCouncil, opt => opt.MapFrom(s => s.RegionalCouncil))


                //.ForMember(t => t.RelationshipType, opt => opt.MapFrom(s => s.RelationshipType))


                .ForMember(t => t.SpecialSchooling, opt => opt.MapFrom(s => s.SpecialSchooling))
                .ForMember(t => t.Status, opt => opt.MapFrom(s => s.Status))
                .ForMember(t => t.TeacherEducation, opt => opt.MapFrom(s => s.TeacherEducation))
                .ForMember(t => t.TerritorialAuthority, opt => opt.MapFrom(s => s.TerritorialAuthority))
                .ForMember(t => t.UrbanArea, opt => opt.MapFrom(s => s.UrbanArea))
                .ForMember(t => t.Ward, opt => opt.MapFrom(s => s.Ward))

                ;


        }
    }
}
