using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;

namespace App.Module11.Infrastructure.Services
{
    public interface IModule11RepositoryService : IRepositoryService
    {
        int CommitBatch();

        void ConfigureBatchProcessing(bool batched = true);

    }
}
