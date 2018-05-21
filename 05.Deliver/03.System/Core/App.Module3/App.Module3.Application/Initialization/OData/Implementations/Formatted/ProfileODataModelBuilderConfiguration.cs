
using System.Data.Entity.Core.Metadata.Edm;
using System.Web.OData.Builder;
using System.Web.OData.Query;
using App.Module3.Application.Constants.Api;
using App.Module3.Shared.Models.Messages.APIs.SIF.V0100.Formated;
using Microsoft.Web.Http;

namespace App.Module3.Application.Initialization.OData.Implementations.Formatted
{
    public class ProfileODataModelBuilderConfiguration : IAppModule3OdataModelBuilderConfiguration
    {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            switch (apiVersion.MajorVersion)
            {
                case 2:
                    ConfigureV2(builder);
                    break;
                default:
                    ConfigureV1(builder);
                    break;

            }
            

        }


        private void ConfigureV1(ODataModelBuilder builder)
        {
            Define(builder);
        }

        private void ConfigureV2(ODataModelBuilder builder)
        {
            DefineSifSchoolServiceDto(builder);
            DefineSifOrganisationDto(builder);
            var entity = Define(builder);
            entity.HasRequired(a => a.Organisation);
            entity.HasRequired(a => a.SchoolService);
        }

        public EntityTypeConfiguration<SifProviderDto> Define(ODataModelBuilder builder)
        {
            var entity = builder.EntitySet<SifProviderDto>(ApiControllerNames.FormattedProvider).EntityType;
            entity.HasKey(x => x.LocalId);
            return entity;
        }

        private void DefineSifOrganisationDto(ODataModelBuilder builder)
        {
            builder.EntityType<SifPhoneNumberDto>().HasKey(x => x.Type);
            builder.EntityType<SifCommunicationChannelDto>().HasKey(x => x.Type);
            builder.EntityType<SifEmailDto>().HasKey(x => x.Type);
            builder.EntityType<SifRelatedOrganisationDto>().HasKey(x => x.RefId);

            DefineSifAddressDto(builder);
            DefineSifContactDto(builder);

            var entity = builder.EntityType<SifOrganisationDto>();
            entity.HasKey(x => x.Name);
            entity.HasMany(x => x.PhoneNumberList);
            entity.HasMany(x => x.AddressList);
            entity.HasMany(x => x.CommunicationChannelList);
            entity.HasMany(x => x.ContactList);
            entity.HasMany(x => x.EmailList);
            entity.HasMany(x => x.RelatedOrganisationList);
        }

        private void DefineSifAddressDto(ODataModelBuilder builder)
        {
            builder.EntityType<SifAddressStreetDto>().HasKey(x => x.Line1);
            var entity = builder.EntityType<SifAddressDto>();
            entity.HasKey(x => x.Type);
            entity.HasRequired(x => x.Street);
        }

        private void DefineSifContactDto(ODataModelBuilder builder)
        {
            var entity = builder.EntityType<SifContactDto>();
            entity.HasKey(x => x.Role);
            entity.HasMany(x => x.PhoneNumberList); // defined elsewhere
            entity.HasMany(x => x.AddressList);  // defined elsewhere
            entity.HasMany(x => x.EmailList);  // defined elsewhere
        }

        private void DefineSifSchoolServiceDto(ODataModelBuilder builder)
        {
            builder.EntityType<SifSchoolYearDto>().HasKey(x => x.YearLevel);
            builder.EntityType<SifEnactedPolicyDto>().HasKey(x => x.Policy);

            var entity = builder.EntityType<SifSchoolServiceDto>();
            entity.HasKey(x => x.Decile);
            //entity.HasMany(x => x.DefinitionList);
            entity.HasMany(x => x.NewEntrantPolicyList);
            entity.HasMany(x => x.SchoolYearList);
        }

        private void AddNavigationProperties(ODataModelBuilder builder)
        {
            //var provider = builder.ComplexType<SifProviderDto>();
            //provider.HasRequired(a => a.Organisation);
            //provider.HasRequired(a => a.SchoolService);
        }
    }
}
