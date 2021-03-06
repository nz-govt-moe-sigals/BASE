﻿namespace App.Module01.Application.Services
{
    using System.Data.Entity;
    using App.Module01.Shared.Models.Entities;

    public interface IExampleApplicationService
    {
        DbSet<Example> GetQueryableSet(string contextKey);

        void Add(Example example);
        void Delete(Example example);
    }
}