namespace App.Core.Infrastructure.Services
{
    public interface IAuthorisationService: IHasAppCoreService
    {
        bool HasRoles(params string[] roles);

        bool HasScope(string scope);

    }
}
