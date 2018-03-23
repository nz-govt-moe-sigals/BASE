namespace App.Core.Infrastructure.Factories
{
    using App.Core.Infrastructure.Integration.Azure.KeyVault;
    using App.Core.Shared.Models.Configuration;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;

    /// <summary>
    /// A Factory to authenticate the Application, 
    /// in order for the Application to retrieve 
    /// values from the keystore.
    /// <para>
    /// Dependencies:
    /// * Nuget:
    ///    * Microsoft.IdentityModel.Clients.ActiveDirectory
    ///      * NOTE: Which relieas on ADAL, as oposed to the newer MSAL...    /// </para>
    /// </summary>
    public class ClientCredentialFactory
    {
        /// <summary>
        /// Build a new ClientCredential 
        /// from the Azure Registered Application's
        /// ClientId and ClientSecret.
        /// </summary>
        /// <param name="aaDClientInfo"></param>
        /// <returns></returns>
        public ClientCredential Build(AadApplicationRegistrationInformation aaDClientInfo)
        {
            //NOTE THAT CLIENT CREDENTIAL comes froms an a library that 
            // is using the older ADAL approach, and will probably get updated to MSAL,
            // hence dragging it out to a Factory:
            var result = new ClientCredential(aaDClientInfo.ClientId, aaDClientInfo.ClientSecret);
            return result;
        }
    }
}
