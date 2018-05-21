namespace App.Core.Infrastructure.IDA.Models.Enums
{
    //Enum to use within Web.Config
    public enum AuthorisationDemoType
    {
        Undefined = 0,
        AADUsingOIDCAndCookies = 1,
        AADUsingOIDCAndBearerTokens = 2,
        AADUsingOIDCAndCookiesAndBearerTokens = 3,

        B2CUsingOIDCAndCookies = 11,
        B2CUsingOIDCAndBearerTokens = 12,
        B2CUsingOIDCAndCookiesAndBearerTokens = 13
    }
}