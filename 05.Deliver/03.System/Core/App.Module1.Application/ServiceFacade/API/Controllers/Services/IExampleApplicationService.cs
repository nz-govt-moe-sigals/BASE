namespace App.Module1.Application.Services
{
    using System.Data.Entity;
    using App.Module1.Shared.Models.Entities;

    public interface IExampleApplicationService
    {
        DbSet<Example> GetQueryableSet(string contextKey);

        void Add(Example example);
        void Delete(Example example);
    }
}