using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services
{
    /// <summary>
    /// Contract for a Service to Authenticate a User
    /// against an internal Store.
    /// </summary>
    public interface IAuthenticationService :  IHasAppCoreService
    {
        /// <summary>
        /// Authenticate a user's credentials - but only if the 
        /// app is persisting Principal credentials, which it REALLY
        /// should NOT be doing.
        /// </summary>
        /// <param name="nameCredential"></param>
        /// <param name="passwordCredential"></param>
        /// <returns></returns>
        bool Authenticate(string nameCredential, string passwordCredential);
    }
}
