using System;

namespace App.Core.Application.ServiceFacade.API.Controllers.V0100
{
    using System.Linq;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Messages.APIs.V0100;

    /// <summary>
    /// OData Queryable REST Controller for
    /// <see cref="ApplicationDescriptionDto"/> messages 
    /// that describe an Application Name, Description, Creator, Distributor,
    /// for use by User Agents to render in Header Views as they see fit.
    /// </summary>
    /// <seealso cref="App.Core.Application.ServiceFacade.API.Controllers.ODataControllerBase" />
    public class ApplicationDescriptionController : ODataControllerBase

    {
        private readonly IApplicationInformationService _applicationInformationService;
        private readonly IObjectMappingService _objectMappingService;


        public ApplicationDescriptionController(IPrincipalService principalService,
            IApplicationInformationService applicationInformationService,
            IObjectMappingService objectMappingService
        ) : base(principalService)
        {
            this._applicationInformationService = applicationInformationService;
            this._objectMappingService = objectMappingService;
        }

        public IQueryable<ApplicationDescriptionDto> Get()
        {
            var result = new[]
            {
                this._objectMappingService.Map<ApplicationDescription, ApplicationDescriptionDto>(this
                    ._applicationInformationService.GetApplicationInformation())
            };

            return result.AsQueryable();
        }

        
        //Really doesn't matter what guid we provide (always returns the only one)
        public ApplicationDescriptionDto Get(Guid key)
        {

            var result =
                this._objectMappingService.Map<ApplicationDescription, ApplicationDescriptionDto>(this
                    ._applicationInformationService.GetApplicationInformation());
            return result;
        }
    }
}