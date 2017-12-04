namespace App.Core.Infrastructure.Db.Interception
{
    using System;
    using System.Data.Entity;

    public interface IDbCommitPreCommitProcessingStrategy
    {
        bool Enabled { get; set; }
        Type InterfaceType { get; }
        EntityState[] States { get; }

        void Process(DbContext dbContext);
    }
}