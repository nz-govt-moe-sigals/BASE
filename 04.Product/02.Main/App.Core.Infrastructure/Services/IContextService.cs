using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services
{
    public interface IContextService
    {

    void Set(string key, object value);
        object Get(string key);
    }
}
