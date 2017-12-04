using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Implementations
{

    public class StorageService : IStorageService
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
