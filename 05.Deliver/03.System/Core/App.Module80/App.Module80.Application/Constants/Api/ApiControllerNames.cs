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


        public const string LargeItem = "LargeItems";

        public const string LitterItem = "LitterItems";

        public const string Organisation = "Organisations";

        public const string Region = "Regions";

        public const string Survey = "Surveys";

        public const string SurveyLocation = "SurveyLocations";

        public const string SurveyLargeItem = "SurveyLargeItems";

        public const string SurveyLitterItem = "SurveyLitterItems";
    }
}


