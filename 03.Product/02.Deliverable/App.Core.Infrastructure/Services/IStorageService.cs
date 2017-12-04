using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services
{
    public interface IStorageService : IHasAppCoreService
    {
        void Persist(byte[] bytes, string fileName);
    }
}
