using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.OData.Builder;
using App.Core.Application.Constants.Api;
using App.Core.Shared.Models.Messages.API.V0100;
using Microsoft.Web.Http;

namespace App.Core.Application.Initialization.OData.Implementations
{
    public class EmailODataModelBuilderConfiguration : IAppCoreOdataModelBuilderConfiguration
    {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            Define(builder);
        }

        public EntityTypeConfiguration<EmailDto> Define(ODataModelBuilder builder)
        {
            var entity = builder.EntitySet<EmailDto>(ApiControllerNames.Email).EntityType;
            entity.HasKey(x => x.To);
            return entity;
        }
    }
}
