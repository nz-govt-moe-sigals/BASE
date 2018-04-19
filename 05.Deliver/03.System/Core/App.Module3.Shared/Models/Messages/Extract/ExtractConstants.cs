using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Shared.Models.Messages.Extract
{
    public static class ExtractConstants
    {
        private static readonly Dictionary<string, Type> _lookupDic;
        private static readonly List<string> _destinationtableNames;
        private static readonly List<string> _referenceTableNames;

        static ExtractConstants()
        {
            // Do all the reference data first as it is important to know which one is first
            _lookupDic = new Dictionary<string, Type>();
            _destinationtableNames = new List<string>();
            _referenceTableNames = new List<string>();
            InitDictionary();
            InitReferenceTables();
            InitDestinationTables();


        }

        private static void InitDestinationTables()
        {
            _destinationtableNames.Add(_tableNameSchoolProfiles);
            _destinationtableNames.Add(_tableNameSchoolWGS);
            _destinationtableNames.Add(_tableNameSchoolEnrol);
            _destinationtableNames.Add(_tableNameSchoolLevelGender);
        }

        private static void InitReferenceTables()
        {
            _referenceTableNames.Add(_tableNameReferenceAreaUnits);
            _referenceTableNames.Add(_tableNameReferenceAuthorityType);
            _referenceTableNames.Add(_tableNameReferenceCommunityBoards);
            _referenceTableNames.Add(_tableNameReferenceGeneralElectorate);
            _referenceTableNames.Add(_tableNameReferenceMaoriElectorate);
            _referenceTableNames.Add(_tableNameReferenceOrganisationStatus);
            _referenceTableNames.Add(_tableNameReferenceOrganisationType);
            _referenceTableNames.Add(_tableNameReferenceRegion);
            _referenceTableNames.Add(_tableNameReferenceRegionalCouncil);
            _referenceTableNames.Add(_tableNameReferenceRelationshipType);
            _referenceTableNames.Add(_tableNameReferenceSchoolClassification);
            _referenceTableNames.Add(_tableNameReferenceSchoolingGender);
            _referenceTableNames.Add(_tableNameReferenceSchoolYearLevel);
            _referenceTableNames.Add(_tableNameReferenceSpecialSchooling);
            _referenceTableNames.Add(_tableNameReferenceTeacherEducation);
            _referenceTableNames.Add(_tableNameReferenceTerritorialAuthority);
            _referenceTableNames.Add(_tableNameReferenceUrbanArea);
            _referenceTableNames.Add(_tableNameReferenceWard);
        }

        private static void InitDictionary()
        {
            
            _lookupDic.Add(_tableNameReferenceAreaUnits, typeof(ReferenceAreaUnits));
            _lookupDic.Add(_tableNameReferenceAuthorityType, typeof(ReferenceAuthorityType));
            _lookupDic.Add(_tableNameReferenceCommunityBoards, typeof(ReferenceCommunityBoard));
            _lookupDic.Add(_tableNameReferenceGeneralElectorate, typeof(ReferenceGeneralElectorate));
            _lookupDic.Add(_tableNameReferenceMaoriElectorate, typeof(ReferenceMaoriElectorate));
            _lookupDic.Add(_tableNameReferenceOrganisationStatus, typeof(ReferenceOrganisationStatus));
            _lookupDic.Add(_tableNameReferenceOrganisationType, typeof(ReferenceOrganisationType));
            _lookupDic.Add(_tableNameReferenceRegion, typeof(ReferenceRegion));
            _lookupDic.Add(_tableNameReferenceRegionalCouncil, typeof(ReferenceRegionalCouncil));
            _lookupDic.Add(_tableNameReferenceRelationshipType, typeof(ReferenceRelationshipType));
            _lookupDic.Add(_tableNameReferenceSchoolClassification, typeof(ReferenceSchoolClassification));
            _lookupDic.Add(_tableNameReferenceSchoolingGender, typeof(ReferenceSchoolingGender));
            _lookupDic.Add(_tableNameReferenceSchoolYearLevel, typeof(ReferenceSchoolYearLevel));
            _lookupDic.Add(_tableNameReferenceSpecialSchooling, typeof(ReferenceSpecialSchooling));
            _lookupDic.Add(_tableNameReferenceTeacherEducation, typeof(ReferenceTeacherEducation));
            _lookupDic.Add(_tableNameReferenceTerritorialAuthority, typeof(ReferenceTerritorialAuthority));
            _lookupDic.Add(_tableNameReferenceUrbanArea, typeof(ReferenceUrbanArea));
            _lookupDic.Add(_tableNameReferenceWard, typeof(ReferenceWard));
            _lookupDic.Add(_tableNameSchoolProfiles, typeof(SchoolProfiles));
            _lookupDic.Add(_tableNameSchoolWGS, typeof(SchoolWGS));
            _lookupDic.Add(_tableNameSchoolEnrol, typeof(SchoolEnrol));
            _lookupDic.Add(_tableNameSchoolLevelGender, typeof(SchoolLevelGender));


            //_orderedList.Add(_tableNameSummary, typeof(Summary));
        }

        /// <summary>
        /// Get the list of How the tables are supposed to be executed. 
        /// </summary>
        /// <returns></returns>
        public static List<string> GetReferenceTableList()
        {
            return _referenceTableNames;
        }

        /// <summary>
        /// Get the list of How the tables are supposed to be executed. 
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDestinationTableList()
        {
            return _destinationtableNames;
        }

        public static Type LookupTableNameList(string tableName)
        {
            return _lookupDic[tableName];
        }

        public static string LookupTableNameList(Type tableType)
        {
            return _lookupDic.Where(x => x.Value == tableType).Select(x => x.Key).First();
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
