using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Shared.Models.Messages.API.V0100;

namespace App.Core.Application.Services
{
    public interface IUserProfileService
    {
        void UpdateUserProfile(UserProfileDto dto);

        UserProfileDto GetUserProfile();
    }
}
