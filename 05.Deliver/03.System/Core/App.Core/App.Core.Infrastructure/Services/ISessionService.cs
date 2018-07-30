using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services
{
    using App.Core.Shared.Models.Entities;

    public interface ISessionService
    {
        Session Create(Principal principal, string uniqueCacheId, TimeSpan? timespanToCache = null);

        Session CreateAndSave(Principal principal, string uniqueCacheId, TimeSpan? timespanToCache = null);

        Session Get(string uniqueCacheId, TimeSpan? timespanToCache = null);
    }
}
