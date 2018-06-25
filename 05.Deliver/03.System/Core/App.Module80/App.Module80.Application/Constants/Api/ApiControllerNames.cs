using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Module80.Shared.Contracts;

namespace App.Module80.Application.Constants.Api
{
    public class ApiControllerNames: IHasModuleSpecificIdentifier
    {
        public static string PathRoot = Infrastructure.Constants.Module.Names.ModuleKey.ToLower();


        public static string Example = "Example";
    }
}


