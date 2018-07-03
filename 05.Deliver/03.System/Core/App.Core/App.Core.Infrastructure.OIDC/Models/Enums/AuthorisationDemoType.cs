namespace App.Core.Infrastructure.IDA.Models.Enums
{
    //Enum to use within Web.Config
    public enum AuthorisationDemoType
    {
        Undefined = 0,
        AadUsingOidcAndCookies = 1,
        AadUsingOidcAndBearerTokens = 2,
        AadUsingOidcAndCookiesAndBearerTokens = 3,

        B2CUsingOidcAndCookies = 11,
        B2CUsingOidcAndBearerTokens = 12,
        B2CUsingOidcAndCookiesAndBearerTokens = 13,

        OktaUsingOidcAndCookies = 21,
        OktaUsingOidcAndBearerTokens = 22,
        OktaUsingOidcAndCookiesAndBearerTokens = 23
    }
}