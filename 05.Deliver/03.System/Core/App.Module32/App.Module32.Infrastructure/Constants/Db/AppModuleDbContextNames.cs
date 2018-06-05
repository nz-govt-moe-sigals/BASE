using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Module32.Shared.Contracts;

namespace App.Module32.Infrastructure.Constants.Db
{
    public class AppModuleDbContextNames:IHasModuleSpecificIdentifier
    {
        // For now, only one db per Module, but could be more at some point:
        public const string Default = Constants.Module.Names.ModuleKey;
    }
}


