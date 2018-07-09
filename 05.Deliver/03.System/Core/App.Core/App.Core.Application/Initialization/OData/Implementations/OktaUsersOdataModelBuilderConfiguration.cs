using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.OData.Builder;
using App.Core.Application.Constants.Api;
using App.Core.Infrastructure.IDA.Models;
using App.Core.Shared.Models.Messages.API.V0100;
using Microsoft.Web.Http;

namespace App.Core.Application.Initialization.OData.Implementations
{
    public class OktaUsersOdataModelBuilderConfiguration : IAppCoreOdataModelBuilderConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataClassificationOdataModelBuilderConfiguration"/> class.
        /// </summary>
        /// <internal>
        /// Remember to make these constructors public or reflection for 
        /// <see cref="IAppCoreOdataModelBuilderConfiguration"/> won't find them.
        /// </internal>
        public OktaUsersOdataModelBuilderConfiguration()
        {
        }


        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {

            Define(builder);
        }


        public EntityTypeConfiguration<OktaUser> Define(ODataModelBuilder builder)
        {
            var entity = builder.EntitySet<OktaUser>("OktaUsers").EntityType;
            entity.HasKey(x => x.Id);
            return entity;
        }
    }
}
