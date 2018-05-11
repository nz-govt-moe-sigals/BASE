using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Application.Constants.Api
{
    public static class ApiControllerNames
    {


        // Even if not used, keep, in order to keep relationship
        // withou ModuleKey:
        internal static string PathRootOriginal = Infrastructure.Constants.Module.Names.ModuleKey.ToLower();

        /// <summary>
        /// The root of the path to API/OData Controllers within this module.
        /// ie: foo.com/odata/educationproviders/genders/
        /// </summary>
        public static string PathRoot = "EducationProviders".ToLower();


        public const string Example = "exampledto";

        // Note that the paths to the controllers will be registered in lower case...

        public const string Suffix = "";
        // Reference Data:
        public const string AreaUnit = "AreaUnit" + Suffix;
        public const string AuthorityType = "AuthorityType" + Suffix;
        public const string CommunityBoard = "CommunityBoard" + Suffix;
        public const string GeneralElectorate = "GeneralElectorate" + Suffix;
        public const string MaoriElectorate = "MaoriElectorate" + Suffix;
        public const string EducationProviderType = "EducationProviderType" + Suffix;
        public const string EducationProviderStatus = "EducationProviderStatus" + Suffix;
        public const string Region = "Region" + Suffix;
        public const string RegionalCouncil = "RegionalCouncil" + Suffix;
        public const string RelationshipType = "RelationshipType" + Suffix;
        public const string EducationProviderClassification = "EducationProviderClassification" + Suffix;
        public const string SchoolingGender = "SchoolingGender" + Suffix;
        public const string EducationProviderYearLevel = "EducationProviderYearLevel" + Suffix;
        public const string SpecialSchooling = "SpecialSchooling" + Suffix;
        public const string TeacherEducation = "TeacherEducation" + Suffix;
        public const string TerritorialAuthority = "TerritorialAuthority" + Suffix;
        public const string UrbanArea = "UrbanArea" + Suffix;
        public const string Ward = "Ward" + Suffix;
        // Resources:

        public const string EducationProviderRollCount = "EducationProviderRollCount" + Suffix;

        public const string EducationProvider = "EducationProvider" + Suffix;

        public const string FormattedProvider = "Providers" + Suffix;

    }
}
