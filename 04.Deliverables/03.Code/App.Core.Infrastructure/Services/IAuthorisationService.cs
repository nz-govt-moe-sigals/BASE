namespace App.Core.Infrastructure.Services
{
    /// <summary>
    /// Contract for an Infrastructure Service to 
    /// Query whether the current Thread's Principal
    /// is Authorised to perform specific Operations.
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IHasAppCoreService" />
    public interface IAuthorisationService: IHasAppCoreService
    {
        /// <summary>
        /// Determines whether the current thread Principal has roles claims.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <returns>
        ///   <c>true</c> if the specified roles has roles; otherwise, <c>false</c>.
        /// </returns>
        bool HasRoles(params string[] roles);

        /// <summary>
        /// Determines whether the current thread Principal has scope.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <returns>
        ///   <c>true</c> if the specified scope has scope; otherwise, <c>false</c>.
        /// </returns>
        bool HasScope(string scope);

    }
}
