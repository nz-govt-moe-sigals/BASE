namespace App.Core.Infrastructure.Db.Interception.Implementations.Base
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models;

    /// <summary>
    ///     Abstract base class for a strategy to be applied when persisting changes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DbContextPreCommitProcessingStrategyBase<T> : IDbCommitPreCommitProcessingStrategy
        where T : class
    {
        /// <summary>
        ///     The _current user
        /// </summary>
        protected string _currentUser;

        /// <summary>
        /// </summary>
        protected DbChangeTracker _dbChangeTracker;

        /// <summary>
        /// </summary>
        protected DbContext _dbContext;


        // ReSharper disable InconsistentNaming
        /// <summary>
        ///     The interface the <see cref="DbEntityEntry.Entity" /> must match before the Strategy is applied.
        /// </summary>
        protected /*readonly*/ Type _interfaceType;
        // ReSharper restore InconsistentNaming

        /// <summary>
        ///     The _now UTC
        /// </summary>
        protected DateTimeOffset _nowUtc;


        /// <summary>
        ///     Initializes a new instance of the <see cref="DbContextPreCommitProcessingStrategyBase{T}" /> class.
        /// </summary>
        /// <param name="principalService"></param>
        /// <param name="states">The states.</param>
        /// <param name="dateTimeService"></param>
        protected DbContextPreCommitProcessingStrategyBase(
            IUniversalDateTimeService dateTimeService,
            IPrincipalService principalService,
            params EntityState[] states)
        {
            this.Enabled = true;
            this._interfaceType = typeof(T);
            this._dateTimeService = dateTimeService;
            this._dateTimeService = dateTimeService;
            this._principalService = principalService;
            this._states = states;
        }

        /// <summary>
        ///     The interface the <see cref="DbEntityEntry.Entity" /> must match before the Strategy is applied.
        /// </summary>
        /// <value></value>
        public Type InterfaceType => this._interfaceType;

        /// <summary>
        ///     The <see cref="EntityState" /> the <see cref="DbEntityEntry.State" /> must match before the Strategy is applied.
        /// </summary>
        /// <value></value>
        public EntityState[] States => this._states;


        /// <summary>
        ///     Gets or sets a value indicating whether this object is enabled.
        ///     <para>Member defined in<see cref="IHasEnabled" /></para>
        /// </summary>
        public bool Enabled { get; set; }


        /// <summary>
        ///     Processes the specified db change tracker,
        ///     iterating through all the Entities in it,
        ///     applying <see cref="IDbCommitPreCommitProcessingStrategy" /> strategies that match.
        /// </summary>
        public virtual void Process(DbContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbChangeTracker = this._dbContext.ChangeTracker;

            this._nowUtc = this._dateTimeService.NowUtc();
            this._currentUser = this._principalService.CurrentName;

            this.Enabled = true;


            //Iterate through entities
            //Could only find a way to interate through all entities
            //so loop through them first (there won't be many in most cases):
            foreach (var dbEntityEntry in this._dbChangeTracker.Entries())
            {
                //Get the Entity Type (History, Vertex, etc.)
                //In order to find out if any interfaces the entity impleemnts
                //match cached save strategies:
                var entityType = dbEntityEntry.Entity.GetType();

                if (!this.InterfaceType.IsAssignableFrom(entityType))
                {
                    //Go to next entity:
                    continue;
                }
                //Have an entity that matches interface, so ok to process:
                var entity = InspectDbEntityEntry(dbEntityEntry);
                if (entity != null)
                {
                    PreProcessEntity(entity);
                }
            }
        }


        /// <summary>
        ///     Apply the strategy to the given <see cref="DbEntityEntry" />.
        ///     <para>
        ///     </para>
        /// </summary>
        /// <param name="dbEntityEntry">The <see cref="DbEntityEntry" />.</param>
        protected virtual T InspectDbEntityEntry(DbEntityEntry dbEntityEntry)
        {
            foreach (var dbEntityEntry2 in this.States)
            {
                if (((int) dbEntityEntry.State).BitIsSet((int) dbEntityEntry2))
                {
                    return dbEntityEntry.Entity as T;
                }
            }
            return null;
        }


        /// <summary>
        ///     Gets the state of the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        protected EntityState GetEntityState(T entity)
        {
            return this._dbContext.Entry(entity).State;
        }

        /// <summary>
        ///     Determines whether [is entity state set] [the specified entity].
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="entityState">State of the entity.</param>
        /// <returns></returns>
        protected bool IsEntityStateSet(T entity, EntityState entityState)
        {
            return ((int) GetEntityState(entity)).BitIsSet((int) entityState);
        }


        /// <summary>
        ///     Process the entity before Persisting changes.
        ///     <para>
        ///         An example could be something like:
        ///         <example>
        ///             <code>
        /// <![CDATA[
        /// protected override void ProcessInternal(IHasDistributedIdentity entity) {
        ///   IEnvironmentService environmentService = DependencyResolver.Current.GetInstance<IEnvironmentService>();
        ///   entity.MachineId = environmentService.DeviceUniqueId;
        /// }
        /// ]]>
        /// </code>
        ///         </example>
        ///     </para>
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected abstract void PreProcessEntity(T entity);


        // ReSharper disable InconsistentNaming
        /// <summary>
        ///     The _date time service
        /// </summary>
        protected readonly IUniversalDateTimeService _dateTimeService;

        /// <summary>
        ///     The _principal service
        /// </summary>
        protected readonly IPrincipalService _principalService;

        /// <summary>
        ///     The <see cref="EntityState" /> the <see cref="DbEntityEntry.State" /> must match before the Strategy is applied.
        /// </summary>
        protected /*readonly*/ EntityState[] _states;
        // ReSharper restore InconsistentNaming
    }
}