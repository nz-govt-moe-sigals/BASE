using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using App.Module11.Infrastructure.ExtensionMethods;
using App.Module11.Shared.Constants.Sif;
using App.Module11.Shared.Models.Entities;
using App.Module11.Shared.Models.Messages.APIs.SIF.V0100;
using App.Module11.Shared.Models.Messages.APIs.SIF.V0100.Formated;
using AutoMapper;

namespace App.Module11.Infrastructure.Initialization.ObjectMaps.Messages.SIF.V0100.Formatted
{

    /// <summary>
    /// Warning : I couldn't make this Projectable, So if you are awesome and manage to do it full credit to you
    /// </summary>
    public class ObjectMap_EducationProvider_SifProviderDto
      : IHasAutomapperInitializer

    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<EducationProviderProfile, SifProviderDto>()
                .ForMember(x => x.RefId, opt => opt.MapFrom(src => src.SchoolId))
                .ForMember(x => x.LocalId, opt => opt.MapFrom(src => src.SchoolId))
                .ForMember(x => x.Authority, opt => opt.Ignore())
                .ForMember(x => x.Organisation, opt => opt.Ignore())
                .ForMember(x => x.SchoolService, opt => opt.Ignore())
                ;

            config.CreateMap<EducationProviderDto, SifProviderDto>()
                .ForMember(x => x.RefId, opt => opt.MapFrom(src => src.SchoolId))
                .ForMember(x => x.LocalId, opt => opt.MapFrom(src => src.SchoolId))
                .ForMember(x => x.Authority, opt => opt.ResolveUsing(src => src.AuthorityType != null ? src.AuthorityType.Id : null))
                .ForMember(x => x.Organisation, opt => opt.ResolveUsing<OrganisationResolver>())
                .ForMember(x => x.SchoolService, opt => opt.ResolveUsing<SchoolResolver>())
                ;

        }
    }

    public class OrganisationResolver : IValueResolver<EducationProviderDto, SifProviderDto, SifOrganisationDto>
    {
        public SifOrganisationDto Resolve(EducationProviderDto src, SifProviderDto dest, SifOrganisationDto member, ResolutionContext context)
        {
            var obj = new SifOrganisationDto();
            ResolveAddress(obj, src);
            ResolveEmail(obj, src);
            ResolveCommunicationChannel(obj, src);
            ResolveContact(obj, src);
            obj.EducationRegion = src.Region != null ? src.Region.Id : null;
            obj.Name = src.Name;
            obj.OperationalStatus = src.Status != null ? src.Status.Id : null;
            obj.Type = src.EducationProviderType != null ? src.EducationProviderType.Id : null;
            ResolvePhoneNumber(obj, src);
            ResolveOrgranisation(obj, src);
            return obj;
        }

        private void ResolveOrgranisation(SifOrganisationDto obj, EducationProviderDto src)
        {
            obj.RelatedOrganisationList = new List<SifRelatedOrganisationDto>();
            if (src.CoL != null)
            {
                obj.RelatedOrganisationList.Add(new SifRelatedOrganisationDto()
                {
                    LocalId = src.CoL.Id,
                    RefId = src.CoL.Id,
                    OrangisationType = SifOrganisationTypeType.CommunityOfLearning.GetDescription(),
                    ObjectType = SifDataObjectsTypeType.EducationOrganisation.GetName(),
                    Name = src.CoL.Text
                });
            }
            if (src.LocalOffice != null)
            {
                obj.RelatedOrganisationList.Add(new SifRelatedOrganisationDto()
                {
                    LocalId = src.LocalOffice.Id,
                    RefId = src.LocalOffice.Id,
                    OrangisationType = SifOrganisationTypeType.MinistryOfEducationLocalOffice.GetDescription(),
                    ObjectType = SifDataObjectsTypeType.EducationOrganisation.GetName(),
                    Name = src.LocalOffice.Text
                });
            }
        }

        private void ResolvePhoneNumber(SifOrganisationDto obj, EducationProviderDto src)
        {
            obj.PhoneNumberList = new List<SifPhoneNumberDto>();
            if (!string.IsNullOrWhiteSpace(src.Telephone))
            {
                obj.PhoneNumberList.Add(new SifPhoneNumberDto()
                {
                    Type = SifTelephoneNumberTypeType.Main.GetDescription(),
                    Number = src.Telephone
                });
            }
            if (!string.IsNullOrWhiteSpace(src.Fax))
            {
                obj.PhoneNumberList.Add(new SifPhoneNumberDto()
                {
                    Type = SifTelephoneNumberTypeType.Fax.GetDescription(),
                    Number = src.Fax
                });
            }

        }

        private void ResolveContact(SifOrganisationDto obj, EducationProviderDto src)
        {
            obj.ContactList = new List<SifContactDto>();
            if (!string.IsNullOrWhiteSpace(src.Contact1Name))
            {
                obj.ContactList.Add(new SifContactDto()
                {
                    Name = new SifContactNameDto(src.Contact1Name),
                    Role = src.Contact1Role
                });
            }
            if (!string.IsNullOrWhiteSpace(src.Contact2Name))
            {
                obj.ContactList.Add(new SifContactDto()
                {
                    Name = new SifContactNameDto(src.Contact2Name),
                    Role = src.Contact2Role
                });
            }
        }

        private void ResolveAddress(SifOrganisationDto obj, EducationProviderDto src)
        {
            obj.AddressList = new List<SifAddressDto>();
            //assuming logic on address line 1 should always be populated if others are
            if (!string.IsNullOrWhiteSpace(src.Address1Line1) || !string.IsNullOrWhiteSpace(src.Address1City)
                                                              || !string.IsNullOrWhiteSpace(src.Address1PostalCode) || !string.IsNullOrWhiteSpace(src.Address1Suburb))
            {
                obj.AddressList.Add(new SifAddressDto()
                {
                    Type = SifAddressTypeType.Thoroughfare.GetDescription(),
                    City = src.Address1City,
                    Street = new SifAddressStreetDto()
                    {
                        Line1 = src.Address1Line1,
                        Line2 = src.Address1Line2,
                        Line3 = src.Address1Line3
                    },
                    PostalCode = src.Address1PostalCode,
                    Suburb = src.Address1Suburb
                });
            }
            if (!string.IsNullOrWhiteSpace(src.Address2Line1) || !string.IsNullOrWhiteSpace(src.Address2City)
                                                              || !string.IsNullOrWhiteSpace(src.Address2PostalCode) || !string.IsNullOrWhiteSpace(src.Address2Suburb))
            {
                obj.AddressList.Add(new SifAddressDto()
                {
                    Type = SifAddressTypeType.Thoroughfare.GetDescription(),
                    City = src.Address2City,
                    Street = new SifAddressStreetDto()
                    {
                        Line1 = src.Address2Line1,
                        Line2 = src.Address2Line2,
                        Line3 = src.Address2Line3
                    },
                    PostalCode = src.Address2PostalCode,
                    Suburb = src.Address2Suburb
                });
            }
        }

        private void ResolveEmail(SifOrganisationDto obj, EducationProviderDto src)
        {
            obj.EmailList = new List<SifEmailDto>();
            if (!string.IsNullOrWhiteSpace(src.Email))
            {
                obj.EmailList.Add(new SifEmailDto()
                {
                    Type = SifEmailTypeType.Primary.GetDescription(),
                    Address = src.Email
                });
                
            }
               
        }

        private void ResolveCommunicationChannel(SifOrganisationDto obj, EducationProviderDto src)
        {
            obj.CommunicationChannelList = new List<SifCommunicationChannelDto>();
            if (!string.IsNullOrWhiteSpace(src.Email))
            {
                obj.CommunicationChannelList.Add(new SifCommunicationChannelDto()
                {
                    Type = SifCommunicationChannelTypeType.Website.GetDescription(),
                    Value = src.Url
                });
            }

        }
    }

    public class SchoolResolver : IValueResolver<EducationProviderDto, SifProviderDto, SifSchoolServiceDto>
    {
        public SifSchoolServiceDto Resolve(EducationProviderDto src, SifProviderDto dest, SifSchoolServiceDto member, ResolutionContext context)
        {
            var obj = new SifSchoolServiceDto();
            obj.CoEdStatus = src.SchoolingGender != null ? src.SchoolingGender.Id : null;
            obj.Decile = src.Decile ?? 0;
            ResolveDefinition(obj, src);
            ResolveNewEntrantPolicy(obj, src);
            ResolveSchoolYear(obj, src);
            return obj;
        }

        private void ResolveDefinition(SifSchoolServiceDto obj, EducationProviderDto src)
        {
            obj.DefinitionList = new List<string>();
            if (src.Classification != null)
            {
                obj.DefinitionList.Add(src.Classification.Id);
            }

        }

        private void ResolveNewEntrantPolicy(SifSchoolServiceDto obj, EducationProviderDto src)
        {
            obj.NewEntrantPolicyList = new List<SifEnactedPolicyDto>();
            // err yeah???? Dunno

        }

        private void ResolveSchoolYear(SifSchoolServiceDto obj, EducationProviderDto src)
        {
            obj.SchoolYearList = new List<SifSchoolYearDto>();
            foreach (var levelgender in src.LevelGender)
            {
                if (levelgender.Gender != null && levelgender.Level != null)
                {
                    obj.SchoolYearList.Add(new SifSchoolYearDto()
                    {
                        Gender = levelgender.Gender.Id,
                        YearLevel = levelgender.Level.Id
                    });
                }
            }
        }

    }
}
