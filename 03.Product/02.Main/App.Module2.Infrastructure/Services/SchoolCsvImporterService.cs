namespace App.Module2.Services
{
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using App.Core.Infrastructure.Services;
    using App.Module2.Shared.Models.Configuration;
    using App.Module2.Shared.Models.Entities;
    using CsvHelper;

    public class SchoolCsvImporterService
    {
        private readonly IHostSettingsService _hostSettingsService;

        public SchoolCsvImporterService(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public SchoolDescriptionRaw[] Import(string relativePath = "./DbContextSeederData/SchoolDirectory.csv")
        {
            var executable = Assembly.GetExecutingAssembly().Location;
            var path = Path.GetDirectoryName(executable);
            path = Path.Combine(path, relativePath);

            if (!File.Exists(path))
            {
                var configuration = this._hostSettingsService.GetObject<SchoolImportConfiguration>();
                path = configuration.CsvSourcePath;
                path = Path.Combine(path, relativePath);
            }
            using (TextReader textReader = File.OpenText(path))
            {
                //CsvHelper.Configuration. config = new CsvConfiguration();
                var csv = new CsvReader(textReader);

                //SchoolID,Name,Telephone,Fax,Email,Principal,SchoolWebsite,Street,Suburb,City,PostalAddress1,PostalAddress2,PostalAddress3,PostalCode,UrbanArea,School Type,Definition,Authority,Gender of Students,Territorial AuthoritywithAucklandLocalBoard,RegionalCouncil,MinistryofEducationLocalOffice,EducationRegion,GeneralElectorate,MaoriElectorate,CensusAreaUnit,Ward,CommunityofLearningID,CommunityofLearningName,Longitude ,Latitude,Decile,TotalSchoolRoll,EuropeanPakeha,Maori,Pasifika,Asian,MELAA,Other,InternationalStudents

                var records = csv.GetRecords<SchoolDescriptionRaw>();

                return records.ToArray();
            }
        }
    }

    //public sealed class MyClassMap : CsvClassMap<School>
    //{
    //    public MyClassMap()
    //    {
    //        //School ID,Name,Telephone,Fax,Email^,Principal*,School website,Street,Suburb,City,Postal Address 1,Postal Address 2,Postal Address 3,Postal Code,Urban Area,School Type,Definition,Authority,Gender of Students,Territorial Authority with Auckland Local Board,Regional Council,Ministry of Education Local Office,Education Region,General Electorate,Maori Electorate,Census Area Unit,Ward,Community of Learning: ID,Community of Learning: Name,Longitude ,Latitude,Decile,Total School Roll,European/ Pakeha,Maori,Pasifika,Asian,MELAA,Other,International Students

    //        Map(m => m.Id);
    //        Map(m = > m.Name);
    //    }
    //}
}