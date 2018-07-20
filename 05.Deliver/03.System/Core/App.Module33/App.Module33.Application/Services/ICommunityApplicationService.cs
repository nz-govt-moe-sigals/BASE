namespace App.Module33.Application.Services
{
    using System.Data.Entity;
    using App.Module33.Shared.Models.Entities;

    public interface ICommunityApplicationService
    {
        DbSet<Community> GetQueryableSet(string contextKey);

        void Add(Community community);
        void Delete(Community community);
    }
}

