namespace App.Module2.Application.Services
{
    using System.Data.Entity;
    using App.Module2.Shared.Models.Entities;

    public interface IExampleApplicationService
    {
        DbSet<Example> GetQueryableSet(string contextKey);

        void Add(Example example);
        void Delete(Example example);
    }
}