using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Implementations
{

    /// <summary>
    ///     Implementation of the
    ///     <see cref="IStorageService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IStorageService" />
    public class StorageService : AppCoreServiceBase, IStorageService
    {
        private readonly ITransientLocalFileStorageService _transientLocalFileStorageService;

        public StorageService(ITransientLocalFileStorageService transientLocalFileStorageService)
        {
            this._transientLocalFileStorageService = transientLocalFileStorageService;

        }
        public void Persist(byte[] bytes, string fileName)
        {
            this._transientLocalFileStorageService.Persist(bytes, fileName);
        }
    }

}
