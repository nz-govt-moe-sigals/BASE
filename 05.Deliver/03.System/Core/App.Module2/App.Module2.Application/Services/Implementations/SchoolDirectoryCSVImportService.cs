//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace App.Module02.Application.Services.Implementations
//{
//    using System.IO;
//    using App.Module02.Shared.Models.Entities;

//    public class SchoolDirectoryCSVImportService : ISchoolDirectoryCSVImportService
//    {

//        public SchoolDescriptionRaw[] Import(string relativePath = "./DbContextSeederData/SchoolDirectory.csv")
//        {


//            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
//            string path = (System.IO.Path.GetDirectoryName(executable));
//            path = System.IO.Path.Combine(path, relativePath);

//            if (!File.Exists(path))
//            {
//                path = _hostSettingsService.Get["CodeFirstSeedingDataPath"];
//                path = System.IO.Path.Combine(path, relativePath);
//            }
//            using (TextReader textReader = File.OpenText(path))
//            {

//                CsvConfiguration config = new CsvConfiguration();
//                var csv = new CsvReader(textReader);

//                //SchoolID,Name,Telephone,Fax,Email,Principal,SchoolWebsite,Street,Suburb,City,PostalAddress1,PostalAddress2,PostalAddress3,PostalCode,UrbanArea,School Type,Definition,Authority,Gender of Students,Territorial AuthoritywithAucklandLocalBoard,RegionalCouncil,MinistryofEducationLocalOffice,EducationRegion,GeneralElectorate,MaoriElectorate,CensusAreaUnit,Ward,CommunityofLearningID,CommunityofLearningName,Longitude ,Latitude,Decile,TotalSchoolRoll,EuropeanPakeha,Maori,Pasifika,Asian,MELAA,Other,InternationalStudents

//                var records = csv.GetRecords<SchoolDescriptionRaw>();

//                return records.ToArray();
//            }

//        }
//    }

//    public class SchoolImportRecord
//    {
//        public int ID
//        {
//            get; set;
//        }
//        public string Name
//        {
//            get; set;
//        }
//        public string Telephone
//        {
//            get; set;
//        }
//        public string Fax
//        {
//            get; set;
//        }
//        public string Email
//        {
//            get; set;
//        }
//        public string Principal
//        {
//            get; set;
//        }
//        public string Website
//        {
//            get; set;
//        }
//        public string Street
//        {
//            get; set;
//        }
//        public string Suburb
//        {
//            get; set;
//        }
//        public string City
//        {
//            get; set;
//        }
//        public string PostalAddress1
//        {
//            get; set;
//        }
//        public string PostalAddress2
//        {
//            get; set;
//        }
//        public string PostalAddress3
//        {
//            get; set;
//        }
//        public string PostalCode
//        {
//            get; set;
//        }
//        public string UrbanArea
//        {
//            get; set;
//        }
//        public string SchoolType
//        {
//            get; set;
//        }
//        public string Definition
//        {
//            get; set;
//        }
//        public string Authority
//        {
//            get; set;
//        }
//        public string Gender
//        {
//            get; set;
//        }
//        public string TerritorialAuthoritywithAucklandLocalBoard
//        {
//            get; set;
//        }
//        public string RegionalCouncil
//        {
//            get; set;
//        }
//        public string MOELocalOffice
//        {
//            get; set;
//        }
//        public string EducationRegion
//        {
//            get; set;
//        }
//        public string GeneralElectorate
//        {
//            get; set;
//        }
//        public string MaoriElectorate
//        {
//            get; set;
//        }
//        public string CensusAreaUnit
//        {
//            get; set;
//        }
//        public string Ward
//        {
//            get; set;
//        }
//        public string COLID
//        {
//            get; set;
//        }
//        public string COLName
//        {
//            get; set;
//        }
//        public string Longitude
//        {
//            get; set;
//        }
//        public string Latitude
//        {
//            get; set;
//        }
//        public string Decile
//        {
//            get; set;
//        }
//        public string TotalSchoolRoll
//        {
//            get; set;
//        }
//        public string EuropeanPakeha
//        {
//            get; set;
//        }
//        public string Maori
//        {
//            get; set;
//        }
//        public string Pasifika
//        {
//            get; set;
//        }
//        public string Asian
//        {
//            get; set;
//        }
//        public string MELAA
//        {
//            get; set;
//        }
//        public string Other
//        {
//            get; set;
//        }
//        public string InternationalStudents
//        {
//            get; set;
//        }
//    }

//    //public sealed class MyClassMap : CsvClassMap<School>
//    //{
//    //    public MyClassMap()
//    //    {
//    //        //School ID,Name,Telephone,Fax,Email^,Principal*,School website,Street,Suburb,City,Postal Address 1,Postal Address 2,Postal Address 3,Postal Code,Urban Area,School Type,Definition,Authority,Gender of Students,Territorial Authority with Auckland Local Board,Regional Council,Ministry of Education Local Office,Education Region,General Electorate,Maori Electorate,Census Area Unit,Ward,Community of Learning: ID,Community of Learning: Name,Longitude ,Latitude,Decile,Total School Roll,European/ Pakeha,Maori,Pasifika,Asian,MELAA,Other,International Students

//    //        Map(m => m.Id);
//    //        Map(m = > m.Name);
//    //    }
//    //}

//}
//}
