namespace App.Core.Infrastructure.Initialization.Implementations
{
    using App.Core.Infrastructure.Initialization.Authentication;

    public class HasOidcScopeInitializer : IHasOidcScopeInitializer
    {
        public string[] FullyQualifiedScopeDefinitions => new string[] { };
    }
}