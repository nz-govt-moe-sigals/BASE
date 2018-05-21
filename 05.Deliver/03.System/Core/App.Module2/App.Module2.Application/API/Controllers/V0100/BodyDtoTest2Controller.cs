using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module2.Application.ServiceFacade.API.Controllers.V0100
{
    using System.Collections.ObjectModel;
    using System.Web.OData;
    using App.Core.Application.ServiceFacade.API.Controllers.Base.Base;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using App.Module2.Shared.Models.Entities;
    using App.Module2.Shared.Models.Messages.V0100;

    /// <summary>
    /// Controller created to see how Odata can return BodyDto objects (hooked together
    /// to all its sub elements such as Names, Properties, Claims) without 
    /// the Automapper stuff in between.... in order to track down why the other controller
    /// is failing.
    /// Notice that it works... (ie, without Automapper being in the picture)
    /// </summary>
    //[ODataRoutePrefix("bodybasic")]
    public class BodyDtoTest2Controller : CommonODataControllerBase
    {

        static ICollection<BodyDto> _cache = new Collection<BodyDto>();

        static BodyDtoTest2Controller()
        {
            BodyDto body = new BodyDto
            {
                Id = 10.ToGuid(),
                RecordState = RecordPersistenceState.Active,
                Type = BodyType.Person
            };
            body.Category = new BodyCategoryDto
            {
                Id = 1.ToGuid(),
                RecordState = RecordPersistenceState.Active,
                Text = "Cat111"
            };

            body.Names.Add(new BodyAliasDto
            {
                Id = 1.ToGuid(),
                RecordState = RecordPersistenceState.Active,
                BodyFK = 10.ToGuid(),
                Name = "foo.bar",
                FirstName = "Foo",
                LastName = "Bar"
            });
            body.Properties.Add(new BodyPropertyDto
            {
                Id = 1.ToGuid(),
                RecordState = RecordPersistenceState.Active,
                BodyFK = 10.ToGuid(),
                Key = "PropA",
                Value = "Foo..."
            });
            body.Claims.Add(new BodyClaimDto
            {
                Id = 1.ToGuid(),
                RecordState = RecordPersistenceState.Active,
                BodyFK = 10.ToGuid(),
                Key = "ClaimA",
                Value = "Bar...",
                AuthorityKey = "MOE",
                Signature = "....................."
            });
            body.Channels.Add(new BodyChannelDto
            {
                Id = 1.ToGuid(),
                RecordState = RecordPersistenceState.Active,
                BodyFK = 10.ToGuid(),
                Protocol = BodyChannelType.Landline,
                Address = "123 foo@bar"
            });

            _cache.Add(body);
        }

        public BodyDtoTest2Controller(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService) : base(diagnosticsTracingService, principalService)
        {

        }


        // GET api/values 
        //[ApplyDataContractResolver]
        //[ApplyProxyDataContractResolverAttribute]
        //[ODataRoute("")]
        [EnableQuery(PageSize = 100)]
        public IQueryable<BodyDto> Get()
        {
            IQueryable<BodyDto> results;
            results =
                _cache.AsQueryable().Where(x => x.RecordState == RecordPersistenceState.Active)
                    .Include(x => x.Names)
                    .Include(x => x.Channels)
                    .Include(x => x.Properties)
                    .Include(x => x.Claims)
                ;

            return results;

        }

        //[ODataRoute("({key})")]
        public BodyDto Get(Guid key)
        {
            return _cache.AsQueryable().SingleOrDefault(x => x.Id == key);
        }

    }
}
