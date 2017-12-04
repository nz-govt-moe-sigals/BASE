namespace App.Core.Infrastructure.Initialization.Authentication
{
    public interface IHasOidcScopeInitializer
    {
        string[] FullyQualifiedScopeDefinitions { get; }
    }
}