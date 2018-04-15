using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services
{

    /// <summary>
    /// Contract for an Infrastructure Service to 
    ///    retrieve MSI (Microsoft's Secure Identity...dumb acronym!) 
    ///     Tokens.
    /// <para>
    ///     The Token can be used to access KeyVault, Databases and other
    ///     Azure services that have been made MSI compatible.
    /// </para>
    /// <para>
    /// When working with a Dev station, the token is built around the 
    /// developer's choice of Identities (usually one that has been associated
    /// to the target Org's AD). When working in the cloud, the identity
    /// will be automatically developed when the AppService was first installed.
    /// </para>
    /// </summary>
    public interface IAuthenticationMsiTokenService
    {
        string GetToken();
        Task<string> GetTokenAsync();
    }
}
