namespace App.Core.Infrastructure.Services
{
    using System;
    using App.Core.Shared.Services;

    internal interface ISecureDataTokenService : IHasAppCoreService
    {
        string Get(Guid tokenKey);
        string Save(string value);
    }
}