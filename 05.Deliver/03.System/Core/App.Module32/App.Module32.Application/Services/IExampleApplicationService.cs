﻿namespace App.Module32.Application.Services
{
    using System.Data.Entity;
    using App.Module32.Shared.Models.Entities;

    public interface IExampleApplicationService
    {
        DbSet<Example> GetQueryableSet(string contextKey);

        void Add(Example example);
        void Delete(Example example);
    }
}
