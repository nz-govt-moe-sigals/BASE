namespace App.Core.Application.Oidc
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.IdentityModel.Protocols;
    using Microsoft.Owin.Security.Jwt;

    /// <summary>
    ///     <para></para>
    ///     File used for OIDC validation of incoming API calls (ie, Bearer Token approach)
    ///     <para>
    ///         This class is necessary because the OAuthBearer Middleware does not leverage
    ///         the OpenID Connect metadata endpoint exposed by the STS by default.
    ///     </para>
    /// </summary>
    public class OpenIdConnectCachingSecurityTokenProvider : IIssuerSecurityTokenProvider
    {
        private readonly ConfigurationManager<OpenIdConnectConfiguration> _configManager;

        // persisted in constructor (not used)
        private readonly string _metadataEndpoint;

        // equivalent to (lock) to prevent access across threads.
        private readonly ReaderWriterLockSlim _synclock = new ReaderWriterLockSlim();

        private string _issuer;
        private IEnumerable<SecurityToken> _securityTokens;


        /// <summary>
        /// </summary>
        /// <param name="metadataEndpoint"></param>
        public OpenIdConnectCachingSecurityTokenProvider(string metadataEndpoint)
        {
            this._metadataEndpoint = metadataEndpoint;
            this._configManager = new ConfigurationManager<OpenIdConnectConfiguration>(metadataEndpoint);

            RetrieveMetadata();
        }


        /// <summary>
        ///     Gets the issuer the credentials are for.
        /// </summary>
        /// <value>
        ///     The issuer the credentials are for.
        /// </value>
        public string Issuer
        {
            get
            {
                RetrieveMetadata();
                this._synclock.EnterReadLock();
                try
                {
                    return this._issuer;
                }
                finally
                {
                    this._synclock.ExitReadLock();
                }
            }
        }

        /// <summary>
        ///     Gets all known security tokens.
        /// </summary>
        /// <value>
        ///     All known security tokens.
        /// </value>
        public IEnumerable<SecurityToken> SecurityTokens
        {
            get
            {
                RetrieveMetadata();
                this._synclock.EnterReadLock();
                try
                {
                    return this._securityTokens;
                }
                finally
                {
                    this._synclock.ExitReadLock();
                }
            }
        }


        private void RetrieveMetadata()
        {
            this._synclock.EnterWriteLock();
            try
            {
                var check = 0;
                check = check - 0;
                var start = DateTime.UtcNow;
                var config = Task.Run(this._configManager.GetConfigurationAsync).Result;
                /*
                 * The above sent out the following:
                 * 
                GET https://login.microsoftonline.com/sctb2c01.onmicrosoft.com/discovery/v2.0/keys?p=b2c_1_spike01_signup_policy HTTP/1.1
                Host: login.microsoftonline.com
                Request-Context: appId=cid-v1:fbdfbcf0-b40d-4647-8eaf-7a44c8bf9d33
                x-ms-request-root-id: JFABHN3qqes=
                x-ms-request-id: |JFABHN3qqes=.153fa64a_3.
                Request-Id: |JFABHN3qqes=.153fa64a_3.


                And got back a response will contain available public keys:
                
                HTTP/1.1 200 OK
                Cache-Control: private
                Content-Type: application/json; charset=utf-8
                Server: Microsoft-IIS/8.5
                Set-Cookie: x-ms-cpim-slice=001-000; domain=microsoftonline.com; path=/; secure; HttpOnly
                Set-Cookie: x-ms-cpim-dc=SYD; domain=microsoftonline.com; path=/; secure; HttpOnly
                Set-Cookie: x-ms-cpim-trans=; domain=login.microsoftonline.com; expires=Tue, 25-Jul-2017 02:29:37 GMT; path=/; secure; HttpOnly
                Strict-Transport-Security: max-age=31536000; includeSubDomains
                X-Content-Type-Options: nosniff
                X-Frame-Options: DENY
                X-XSS-Protection: 1; mode=block
                Set-Cookie: x-ms-gateway-slice=001-000; path=/; secure; HttpOnly
                Set-Cookie: stsservicecookie=cpim_te; path=/; secure; HttpOnly
                X-Powered-By: ASP.NET
                Date: Wed, 26 Jul 2017 02:29:37 GMT
                Content-Length: 1817

                {
                  "keys": [
                    {"kid":"IdTokenSigningKeyContainer","use":"sig","kty":"RSA","e":"AQAB","n":"tLDZVZ2Eq_DFwNp24yeSq_Ha0MYbYOJs_WXIgVxQGabu5cZ9561OUtYWdB6xXXZLaZxFG02P5U2rC_CT1r0lPfC_KHYrviJ5Y_Ekif7iFV_1omLAiRksQziwA1i-hND32N5kxwEGNmZViVjWMBZ43wbIdWss4IMhrJy1WNQ07Fqp1Ee6o7QM1hTBve7bbkJkUAfjtC7mwIWqZdWoYIWBTZRXvhMgs_Aeb_pnDekosqDoWQ5aMklk3NvaaBBESqlRAJZUUf5WDFoJh7yRELOFF4lWJxtArTEiQPWVTX6PCs0klVPU6SRQqrtc4kKLCp1AC5EJqPYRGiEJpSz2nUhmAQ"},
                    {"kid":"IdTokenSigningKeyContainer.v2","nbf":1459289287,"use":"sig","kty":"RSA","e":"AQAB","n":"s4W7xjkQZP3OwG7PfRgcYKn8eRYXHiz1iK503fS-K2FZo-Ublwwa2xFZWpsUU_jtoVCwIkaqZuo6xoKtlMYXXvfVHGuKBHEBVn8b8x_57BQWz1d0KdrNXxuMvtFe6RzMqiMqzqZrzae4UqVCkYqcR9gQx66Ehq7hPmCxJCkg7ajo7fu6E7dPd34KH2HSYRsaaEA_BcKTeb9H1XE_qEKjog68wUU9Ekfl3FBIRN-1Ah_BoktGFoXyi_jt0-L0-gKcL1BLmUlGzMusvRbjI_0-qj-mc0utGdRjY-xIN2yBj8vl4DODO-wMwfp-cqZbCd9TENyHaTb8iA27s-73L3ExOQ"},
                    {"kid":"t8zPAboFkCJ9b-nFJzzyIikJgSJAkA2p08ykwRY_1Ao","nbf":1490400391,"use":"sig","kty":"RSA","e":"AQAB","n":"0zUbv8BsDgbMlKthHcA0Eeg-KWR1ePtIZViJczircJ8E_BVvWKxeXutPOw1MC7J1V8eZFViN_8iJVDKl4vER2sb-tdpLQNm9qsJBRTokdLSu9YbjHGUzL55GanujGOBj4k2RGKy1GbEiUpXkYML1DjyPyHEG3Ex_N8ylZ7vdFpjeWX8yzkCd8AjulPdF84bbEau-pW7XW4V58K9I9BDILBemDiJAR8xb5erupeCs7fCMhLliSeMJQQUyCim4S-tuRD6xiNs4LfEyZtSNnC1ujRcOnWHsWdJFj-NYyrojhaDLC3GAZ0DJlqyznsuKMuYWJPT9KUkXi4bpAmDLA8oFFQ"},
                    {"kid":"X5eXk4xyojNFum1kl2Ytv8dlNP4-c57dO6QGTVBwaNk","nbf":1493763266,"use":"sig","kty":"RSA","e":"AQAB","n":"tVKUtcx_n9rt5afY_2WFNvU6PlFMggCatsZ3l4RjKxH0jgdLq6CScb0P3ZGXYbPzXvmmLiWZizpb-h0qup5jznOvOr-Dhw9908584BSgC83YacjWNqEK3urxhyE2jWjwRm2N95WGgb5mzE5XmZIvkvyXnn7X8dvgFPF5QwIngGsDG8LyHuJWlaDhr_EPLMW4wHvH0zZCuRMARIJmmqiMy3VD4ftq4nS5s8vJL0pVSrkuNojtokp84AtkADCDU_BUhrc2sIgfnvZ03koCQRoZmWiHu86SuJZYkDFstVTVSR0hiXudFlfQ2rOhPlpObmku68lXw-7V-P7jwrQRFfQVXw"}
                  ]
                }
                */

                var elapsed = DateTime.UtcNow.Subtract(start);
                this._issuer = config.Issuer;
                this._securityTokens = config.SigningTokens;
            }
            finally
            {
                this._synclock.ExitWriteLock();
            }
        }
    }
}