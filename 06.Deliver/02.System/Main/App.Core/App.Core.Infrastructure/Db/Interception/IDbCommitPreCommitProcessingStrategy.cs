namespace App.Core.Infrastructure.Db.Interception
{
    using System;
    using System.Data.Entity;
    using App.Core.Infrastructure.Services;

    /// <summary>
    /// Contract for implementations of 
    /// Pre-Commit operations. Generally used 
    /// to cleanup new an updated entities to be committed
    /// (add missing dates, etc.)
    /// <para>
    /// Invoked when the Request is wrapping up, 
    /// and invokes <see cref="IUnitOfWorkService"/>'s 
    /// commit operation, 
    /// which in turn invokes each DbContext's SaveChanges, 
    /// which are individually overridden, to in turn 
    /// invoke <see cref="IDbContextPreCommitService"/>
    /// which invokes 
    /// all PreCommitProcessingStrategy implementations, such 
    /// as this.
    /// </para>
    /// </summary>
    public interface IDbCommitPreCommitProcessingStrategy
    {
        bool Enabled { get; set; }
        Type InterfaceType { get; }
        EntityState[] States { get; }

        /// <summary>
        /// Processes the specified database context,
        /// looking for Entities that have characteristics
        /// that match criteria defined by this
        /// ProcessingStrategy implementation.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        void Process(DbContext dbContext);
    }
}