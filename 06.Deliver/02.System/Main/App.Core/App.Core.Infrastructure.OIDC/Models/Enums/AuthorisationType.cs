namespace App.Core.Infrastructure.IDA.Models.Enums
{
    //Enum to use within Web.Config
    public enum AuthorisationType
    {
        Undefined = 0,
        AadUsingOidcAndCookies = 1,
        AadUsingOidcAndBearerTokens = 2,
        AadUsingOidcAndCookiesAndBearerTokens = 3, // use this for combined Api and web Apps only (rare)

        B2CUsingOidcAndCookies = 11,
        B2CUsingOidcAndBearerTokens = 12,
        B2CUsingOidcAndCookiesAndBearerTokens = 13 // use this for combined Api and web Apps only (rare)
    }
}