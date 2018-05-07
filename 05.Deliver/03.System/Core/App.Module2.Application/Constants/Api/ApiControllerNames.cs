using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module2.Application.Constants.Api
{
    public static class ApiControllerNames
    {
        public static string PathRoot = Infrastructure.Constants.Module.Names.ModuleKey.ToLower();


        public static string Suffix = "";
        public static string Body = "Body" + Suffix;
        public static string EducationOrganisation = "EducationOrganisation" + Suffix;


        public static string SchoolAuthority = "SchoolAuthority" + Suffix;
        public static string SchoolDecile = "SchoolDecile" + Suffix;
        public static string SchoolDefinition = "SchoolDefinition" + Suffix;
        public static string SchoolEducationRegion = "SchoolEducationRegion" + Suffix;
        public static string SchoolGender = "SchoolGender" + Suffix;
        public static string SchoolGeneralElectorate = "SchoolGeneralElectorate" + Suffix;
        public static string SchoolMaoriElectorate = "SchoolMaoriElectorate" + Suffix;
        public static string SchoolMinistryOfEducationLocalOffice = "SchoolMinistryOfEducationLocalOffice" + Suffix;
        public static string SchoolRegionalCouncil = "SchoolRegionalCouncil" + Suffix;
        public static string SchoolTerritorialAuthority = "SchoolTerritorialAuthority" + Suffix;
        public static string SchoolType = "SchoolType" + Suffix;
    }
}
