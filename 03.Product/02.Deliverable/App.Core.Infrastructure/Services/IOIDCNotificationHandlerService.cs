

namespace App.Core.Infrastructure.Services
{
    using App.Core.Shared.Models.Messages;


    public interface IOIDCNotificationHandlerService
    {

        void OnAuthenticationSuccess(AuthenticationSuccessMessage authenticationSuccessMessage);
        void OnAuthorizationCodeReceived(AuthorizationCodeReceivedMessage authorizationCodeReceivedMessage);
        void OnAuthenticationError(AuthenticationErrorMessage authenticationErrorMessage);



    }




}
