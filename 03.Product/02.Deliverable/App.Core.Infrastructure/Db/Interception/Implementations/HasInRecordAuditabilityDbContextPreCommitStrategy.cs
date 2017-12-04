namespace App.Core.Infrastructure.Db.Interception.Implementations
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Interception.Implementations.Base;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models;

    public class
        HasInRecordAuditabilityDbContextPreCommitStrategy :
            DbContextPreCommitProcessingStrategyBase<IHasInRecordAuditability>
    {
        public HasInRecordAuditabilityDbContextPreCommitStrategy(IUniversalDateTimeService dateTimeService,
            IPrincipalService principalService) : base(dateTimeService, principalService, EntityState.Added,
            EntityState.Modified, EntityState.Deleted)
        {
        }

        protected override void PreProcessEntity(IHasInRecordAuditability entity)
        {
            if (!entity.CreatedOnUtc.HasValue)
            {
                entity.CreatedOnUtc = this._dateTimeService.NowUtc().UtcDateTime;
            }
            if (entity.CreatedByPrincipalId == null)
            {
                entity.CreatedByPrincipalId = this._principalService.CurrentPrincipalIdentifier ?? "ANON";
            }
            entity.LastModifiedOnUtc = this._dateTimeService.NowUtc().UtcDateTime;
            entity.LastModifiedByPrincipalId = this._principalService.CurrentPrincipalIdentifier ?? "ANON";

            if (IsEntityStateSet(entity, EntityState.Deleted))
            {
                entity.DeletedOnUtc = this._dateTimeService.NowUtc().UtcDateTime;
                entity.DeletedByPrincipalId = this._principalService.CurrentPrincipalIdentifier ?? "ANON";
            }
        }
    }
}