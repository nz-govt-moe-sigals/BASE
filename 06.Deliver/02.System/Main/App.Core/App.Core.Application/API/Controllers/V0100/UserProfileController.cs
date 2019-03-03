using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using App.Core.Application.API.Controllers.Base.Base;
using App.Core.Application.Services;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Messages.API.V0100;

namespace App.Core.Application.API.Controllers.V0100
{
    /// <summary>
    /// Happy for this one just be to be Authenticated and not require core.read as it's you
    /// </summary>
    public class UserProfileController : CommonODataControllerBase
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService,
            IUserProfileService profileService) 
            : base(diagnosticsTracingService, principalService)
        {
            _userProfileService = profileService;
        }

        public UserProfileDto Get()
        {
            return _userProfileService.GetUserProfile();
        }


        [AcceptVerbs("POST", "PUT")]
        public void Post([FromBody] UserProfileDto dto)
        {
            // Ensure this uses Principal service ID not Dto Id 
            _userProfileService.UpdateUserProfile(dto);
        }
    }
}
