namespace App.Core.Infrastructure.Db.Interception.Implementations
{
    using System;
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Interception.Implementations.Base;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;

    public class
        HasTenantFKAuditabilityDbContextPreCommitStrategy : DbContextPreCommitProcessingStrategyBase<IHasTenantFK>
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly ITenantService _tenantService;

        public HasTenantFKAuditabilityDbContextPreCommitStrategy(IUniversalDateTimeService dateTimeService,
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService, ITenantService tenantService) : base(dateTimeService, principalService,
            EntityState.Added)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._tenantService = tenantService;
        }

        protected override void PreProcessEntity(IHasTenantFK entity)
        {
            if (entity.TenantFK.Equals(Guid.Empty))
            {
                try
                {
                    entity.TenantFK = this._tenantService.PrincipalTenant.Id;
                }
                catch
                {
                    this._diagnosticsTracingService.Trace(TraceLevel.Error, "TODO: Tenant management has to be sorted out.");
                }
            }
        }
    }
}