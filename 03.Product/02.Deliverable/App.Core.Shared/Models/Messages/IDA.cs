using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Models.Messages
{
    using System.Security.Claims;

    public class AuthenticationSuccessMessage
    {

        public string UserId { get; set; }

        /// <summary>
        /// The Identity created from the claims, but not
        /// yet set on the thread.
        /// </summary>
        public ClaimsIdentity Identity { get; set; }
    }


    public class AuthorizationCodeReceivedMessage
    {

        public string Name { get; set; }


        /// <summary>
        /// The NameIdentifier of the Identity built from the returned IdP Credentials
        /// But not yet turned into an Thread Identity (certainly not yet turned into
        /// a BearerToken or older style cookie.
        /// </summary>
        public string SignedInUserNameIdentifier { get; set; }
    }

    public class AuthenticationErrorMessage
    {
        public string Error { get; set; }
        public string ErrorDescription { get; set; }
        public string ErrorUri { get; set; }
    }

}
