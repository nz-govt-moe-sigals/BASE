using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module33.Application.Constants.Api
{
    public class ApiControllerNames: IHasModuleSpecificIdentifier
    {
        public static string PathRoot = Infrastructure.Constants.Module.Names.ModuleKey.ToLower();

        public static string Community = "Community";
        public static string CommunityColourScheme = "CommunityColourScheme";
        public static string CoherentPathway = "CoherentPathway";
    }
}


