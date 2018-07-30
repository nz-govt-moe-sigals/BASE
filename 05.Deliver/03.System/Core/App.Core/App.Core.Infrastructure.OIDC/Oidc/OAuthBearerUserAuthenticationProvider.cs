using System;
using System.Collections.Generic;

using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using App.Core.Infrastructure.Constants.IDA;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Core.Infrastructure.Services;
using App.Core.Infrastructure.Services.Implementations;
using App.Core.Shared.Models.Entities;
using App.Core.Shared.Models.Messages;
using Microsoft.Owin.Security.OAuth;

namespace App.Core.Infrastructure.IDA.Oidc
{
    /// <summary>
    /// Only 1 instance of this class anyways
    /// </summary>
    public class OAuthBearerUserAuthenticationProvider : OAuthBearerAuthenticationProvider
    {
        private readonly IOIDCNotificationHandlerService _oidcNotificationHandlerService;
        public OAuthBearerUserAuthenticationProvider(IOIDCNotificationHandlerService oidcNotificationHandlerService)
        {

            _oidcNotificationHandlerService = oidcNotificationHandlerService;
        }


        public override Task ValidateIdentity(OAuthValidateIdentityContext context)
        {
            base.OnValidateIdentity(context);
            _oidcNotificationHandlerService.OnAuthenticationSuccess(
                new AuthenticationSuccessMessage()
                {
                    Identity = context.Ticket.Identity
                }
            );
            return Task.FromResult(0);
        }




    }
}
