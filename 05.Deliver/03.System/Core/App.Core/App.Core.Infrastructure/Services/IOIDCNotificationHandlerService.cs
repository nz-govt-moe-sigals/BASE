

namespace App.Core.Infrastructure.Services
{
    using App.Core.Shared.Models.Messages;


    public interface IOIDCNotificationHandlerService
    {
        /// <summary>
        /// shared logic between 
        /// </summary>
        /// <param name="authenticationSuccessMessage"></param>
        void OnAuthenticationSuccess(AuthenticationSuccessMessage authenticationSuccessMessage);

        void OnAuthorizationCodeReceived(AuthorizationCodeReceivedMessage authorizationCodeReceivedMessage);


        void OnAuthenticationError(AuthenticationErrorMessage authenticationErrorMessage);

        /// <summary>
        /// Cookie based
        /// </summary>
        /// <param name="authenticationSuccessMessage"></param>
        void SecurityTokenValidated(AuthenticationSuccessMessage authenticationSuccessMessage);


    }




}
