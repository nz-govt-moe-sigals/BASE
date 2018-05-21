using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Implementations
{
    using System.Security.Claims;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Messages;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="IOIDCNotificationHandlerService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IOIDCNotificationHandlerService" />
    public class OIDCNotificationHandlerService : AppCoreServiceBase, IOIDCNotificationHandlerService
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IPrincipalService _principalService;
        private readonly IPrincipalManagmentService _principalManagmentService;

        public OIDCNotificationHandlerService(IRepositoryService repositoryService, IPrincipalService principalService, IPrincipalManagmentService principalManagmentService )
        {
            this._repositoryService = repositoryService;
            this._principalService = principalService;
            this._principalManagmentService = principalManagmentService;
        }
        // Invoked by OIDC flows, when successfully authenticated.
        public void OnAuthenticationSuccess(AuthenticationSuccessMessage authenticationSuccessMessage)
        {
            // It's been successful. But note that the identity is 
            // created from the claims. But not yet made onto the thread
            // identity.
            ClaimsIdentity identity = authenticationSuccessMessage.Identity;

            // Need to get IDP's unique identifier for the person
            // Note that each user will have a different one.

            string identityName = identity.Name;

            // Have to find the *record* associated to this sign in.
            //Principal principal = this._principalManagmentService.Get(identityName);


            //identity.AddClaim(
            //    new Claim(
            //        "SystemPrincipalId",
            //        this._principalService.c        "Some value retrieved from the App's DataStore at signin"));

            identity.AddClaim(
                new Claim(
                    "AppCustom",
                "Some value retrieved from the App's DataStore at signin"));
        }

        public void OnAuthorizationCodeReceived(AuthorizationCodeReceivedMessage authorizationCodeReceivedMessage)
        {
            throw new NotImplementedException();
        }

        public void OnAuthenticationError(AuthenticationErrorMessage authenticationErrorMessage)
        {
            throw new NotImplementedException();
        }

    }
}
