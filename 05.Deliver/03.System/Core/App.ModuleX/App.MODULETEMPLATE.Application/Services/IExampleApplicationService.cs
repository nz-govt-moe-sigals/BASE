namespace App.MODULETEMPLATE.Application.Services
{
    using System.Data.Entity;
    using App.MODULETEMPLATE.Shared.Models.Entities;

    public interface IExampleApplicationService
    {
        DbSet<Example> GetQueryableSet(string contextKey);

        void Add(Example example);
        void Delete(Example example);
    }
}














