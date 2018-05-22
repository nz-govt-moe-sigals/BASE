namespace App.Module22.Application.Services
{
    using System.Data.Entity;
    using App.Module22.Shared.Models.Entities;

    public interface ICourseApplicationService
    {
        DbSet<Course> GetQueryableSet(string contextKey);

        void Add(Course course);
        void Delete(Course course);
    }
}

