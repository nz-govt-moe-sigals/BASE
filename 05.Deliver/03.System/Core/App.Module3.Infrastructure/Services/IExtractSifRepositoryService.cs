using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using App.Module3.Shared.Models;

namespace App.Module3.Infrastructure.Services
{
    public interface IExtractSifRepositoryService
    {
        TModel GetSingle<TModel>(string contextKey, Expression<Func<IHasSifSouceDataBase, bool>> filterPredicate)
            where TModel : class, IHasSifSouceDataBase;
    }
}
