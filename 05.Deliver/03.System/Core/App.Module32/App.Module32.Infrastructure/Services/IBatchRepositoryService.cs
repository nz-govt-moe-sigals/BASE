using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models;
using EntityFramework.Utilities;

namespace App.Module32.Infrastructure.Services
{
    public interface IBatchRepositoryService : IRepositoryService
    {
        int CommitBatch();

        void ConfigureBatchProcessing(bool batched = true);

        void InsertAll<TEntity>(IEnumerable<TEntity> list)
            where TEntity : class;

        void UpdateAll<TEntity>(IEnumerable<TEntity> list, Action<UpdateSpecification<TEntity>> updateSpec)
            where TEntity : class;

        void PreProcessEntity(IHasInRecordAuditability entity);

    }
}





