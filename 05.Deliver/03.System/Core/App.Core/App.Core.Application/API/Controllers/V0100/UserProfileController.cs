using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using App.Core.Application.Services;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Messages.API.V0100;

namespace App.Core.Application.API.Controllers.V0100
{
    public class UserProfileController : ODataController
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IDiagnosticsTracingService diagnosticsTracingService,
            IUserProfileService profileService)
        {
            _userProfileService = profileService;
        }

        public UserProfileDto Get()
        {
            return _userProfileService.GetUserProfile();
        }


        public void Put([FromBody] UserProfileDto dto)
        {
            _userProfileService.UpdateUserProfile(dto);
        }
    }
}
