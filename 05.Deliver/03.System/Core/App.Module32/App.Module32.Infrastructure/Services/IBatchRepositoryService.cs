using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;

namespace App.Module32.Infrastructure.Services
{
    public interface IBatchRepositoryService : IRepositoryService
    {
        int CommitBatch();

        void ConfigureBatchProcessing(bool batched = true);

    }
}





