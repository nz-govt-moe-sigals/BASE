using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Attributes;
using App.Core.Shared.Models.Entities;
using App.Core.Shared.Models.Messages.API.V0100;
using AutoMapper.QueryableExtensions;

namespace App.Core.Infrastructure.Cache
{


    /// <summary>
    /// Notice the Key. This is how it gets registered automatically.
    /// </summary>
    [Key(Constants.Cache.StaticKeys.DefaultTenant)]
    public class DefaultTenancyCacheItem : CacheItemBase, IAppCoreCacheItem
    {
        private readonly IRedisCacheService _redisCacheService;
        private readonly IRepositoryService _repositoryService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="redisCacheService"></param>
        public DefaultTenancyCacheItem(IRedisCacheService redisCacheService, IRepositoryService repositoryService)
        {
            _redisCacheService = redisCacheService;

            this._repositoryService = repositoryService;

            this._duration = TimeSpan.FromMinutes(1);
        }

        public override object Get()
        {
            TenantDto result = _redisCacheService.Get<TenantDto>(_key);

            if (result.IsDefaultOrNotInitialized())
            {
                result = _repositoryService
                    .GetQueryableSet<Tenant>(Constants.Db.AppCoreDbContextNames.Core)
                    .Where(x => x.IsDefault == true)
                    .ProjectTo<TenantDto>((object)null, x => x.Properties)
                    .FirstOrDefault(x => true);

                _redisCacheService.Set(_key, result);
            }

            return result;
        }
    }
}
