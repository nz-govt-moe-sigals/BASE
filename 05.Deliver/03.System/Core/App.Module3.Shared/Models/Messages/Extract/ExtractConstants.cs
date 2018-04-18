using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Shared.Models.Messages.Extract
{
    public static class ExtractConstants
    {
        private static readonly Dictionary<string, Type> _orderedList;

        static ExtractConstants()
        {
            // Do all the reference data first as it is important to know which one is first
            _orderedList = new Dictionary<string, Type>();
            _orderedList.Add(_tableNameReferenceAreaUnits, typeof(ReferenceAreaUnits));
             _orderedList.Add(_tableNameReferenceAuthorityType, typeof(ReferenceAuthorityType));
            _orderedList.Add(_tableNameReferenceCommunityBoards, typeof(ReferenceCommunityBoard));
            _orderedList.Add(_tableNameReferenceGeneralElectorate, typeof(ReferenceGeneralElectorate));
            _orderedList.Add(_tableNameReferenceMaoriElectorate, typeof(ReferenceMaoriElectorate));
            _orderedList.Add(_tableNameReferenceOrganisationStatus, typeof(ReferenceOrganisationStatus));
            _orderedList.Add(_tableNameReferenceOrganisationType, typeof(ReferenceOrganisationType));
            _orderedList.Add(_tableNameReferenceRegion, typeof(ReferenceRegion));
            _orderedList.Add(_tableNameReferenceRegionalCouncil, typeof(ReferenceRegionalCouncil));
            _orderedList.Add(_tableNameReferenceRelationshipType, typeof(ReferenceRelationshipType));
            _orderedList.Add(_tableNameReferenceSchoolClassification, typeof(ReferenceSchoolClassification));
            _orderedList.Add(_tableNameReferenceSchoolingGender, typeof(ReferenceSchoolingGender));
            _orderedList.Add(_tableNameReferenceSchoolYearLevel, typeof(ReferenceSchoolYearLevel));
            _orderedList.Add(_tableNameReferenceSpecialSchooling, typeof(ReferenceSpecialSchooling));
            _orderedList.Add(_tableNameReferenceTeacherEducation, typeof(ReferenceTeacherEducation));
            _orderedList.Add(_tableNameReferenceTerritorialAuthority, typeof(ReferenceTerritorialAuthority));
            _orderedList.Add(_tableNameReferenceUrbanArea, typeof(ReferenceUrbanArea));
            _orderedList.Add(_tableNameReferenceWard, typeof(ReferenceWard));
            _orderedList.Add(_tableNameSchoolEnrol, typeof(SchoolEnrol));
            _orderedList.Add(_tableNameSchoolLevelGender, typeof(SchoolLevelGender));
            _orderedList.Add(_tableNameSchoolProfiles, typeof(SchoolProfiles));
            _orderedList.Add(_tableNameSchoolWGS, typeof(SchoolWGS));
            _orderedList.Add(_tableNameSummary, typeof(Summary));


        }

        /// <summary>
        /// Get the list of How the tables are supposed to be executed. 
        /// </summary>
        /// <returns></returns>
        public static List<string> GetOrderedTableNameList()
        {
            return _orderedList.Keys.ToList();
        }

        public static Type LookupTableNameList(string tableName)
        {
            return _orderedList[tableName];
        }

        public static string LookupTableNameList(Type tableType)
        {
            return _orderedList.Where(x => x.Value == tableType).Select(x => x.Key).First();
        }

        // constants of the extract table names 
        public const string _tableNameReferenceAreaUnits = "Schools_Directory_API_Ref_Area_Units";
        public const string _tableNameReferenceAuthorityType = "Schools_Directory_API_Ref_Authority_Type";
        public const string _tableNameReferenceCommunityBoards = "Schools_Directory_API_Ref_Community_Board";
        public const string _tableNameReferenceGeneralElectorate = "Schools_Directory_API_Ref_General_Electorate";
        public const string _tableNameReferenceMaoriElectorate = "Schools_Directory_API_Ref_Maori_Electorate";
        public const string _tableNameReferenceOrganisationStatus = "Schools_Directory_API_Ref_Organisation_Status";
        public const string _tableNameReferenceOrganisationType = "Schools_Directory_API_Ref_Organisation_Type";
        public const string _tableNameReferenceRegion = "Schools_Directory_API_Ref_Region";
        public const string _tableNameReferenceRegionalCouncil = "Schools_Directory_API_Ref_RegionalCouncil";
        public const string _tableNameReferenceRelationshipType = "Schools_Directory_API_Ref_Relationship_Type";
        public const string _tableNameReferenceSchoolClassification = "Schools_Directory_API_Ref_SchoolClassification";
        public const string _tableNameReferenceSchoolingGender = "Schools_Directory_API_Ref_Schooling_Gender";
        public const string _tableNameReferenceSchoolYearLevel = "Schools_Directory_API_Ref_SchoolYearLevel";
        public const string _tableNameReferenceSpecialSchooling = "Schools_Directory_API_Ref_SpecialSchooling";
        public const string _tableNameReferenceTeacherEducation = "Schools_Directory_API_Ref_Teacher_Education";
        public const string _tableNameReferenceTerritorialAuthority = "Schools_Directory_API_Ref_TerritorialAuthority";
        public const string _tableNameReferenceUrbanArea = "Schools_Directory_API_Ref_UrbanArea";
        public const string _tableNameReferenceWard = "Schools_Directory_API_Ref_Ward";
        public const string _tableNameSchoolEnrol = "Schools_Directory_API_School_Enrol";
        public const string _tableNameSchoolLevelGender = "Schools_Directory_API_School_Level_Gender";
        public const string _tableNameSchoolProfiles = "Schools_Directory_API_School_Profiles";
        public const string _tableNameSchoolWGS = "Schools_Directory_API_School_WGS";
        public const string _tableNameSummary = "Schools_Directory_API_Summary";

    }

}
