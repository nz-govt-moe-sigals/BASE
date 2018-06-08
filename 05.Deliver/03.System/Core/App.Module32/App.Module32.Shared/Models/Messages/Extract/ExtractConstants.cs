using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Module32.Shared.Models.Messages.Extract
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
            _destinationtableNames.Add(_tableNameStudentProfiles);
        }

        private static void InitReferenceTables()
        {
            _referenceTableNames.Add(_tableNameSchoolProfiles);
        }

        private static void InitDictionary()
        {
            _lookupDic.Add(_tableNameSchoolProfiles, typeof(SchoolProfile));
            _lookupDic.Add(_tableNameStudentProfiles, typeof(StudentProfile));
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
        public const string _tableNameSchoolProfiles = "Schools_Directory_API_School_Profiles";
        public const string _tableNameStudentProfiles = "Schools_Directory_API_Student_Profiles";
    }

}





