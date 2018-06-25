using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Module32.Infrastructure.Services.Implementations.Base;
using App.Module32.Shared.Models.Entities;
using App.Module32.Shared.Models.Messages.Extract;

namespace App.Module32.Infrastructure.Services.Implementations.Extract.DataServices
{
    public class StudentProfilesExtractService : BaseExtractService<StudentProfile, EducationStudentProfile>
    {
        public StudentProfilesExtractService(IDiagnosticsTracingService tracingService, IExtractAzureDocumentDbService documentDbService, IExtractRepositoryService repositoryService) 
            : base(tracingService, documentDbService, repositoryService)
        {
        }

        //SERIOUS HACK UNDER PRESSURE 
        public override void Process()
        {
            var schools = _repositoryService.GetEducationSchoolProfiles(new List<EducationSchoolProfile>()
            {
                new EducationSchoolProfile() {SchoolId = 1},
                new EducationSchoolProfile(){SchoolId = 2},
            }).ToList();


            var list = new List<EducationStudentProfile>()
            {
                new EducationStudentProfile()
                {
                    FullName = "Robert Muldoon",
                    DateOfBirth = new DateTime(2011,05,05),
                    NSN = "10000",
                    Gender = "M",
                    EducationSchoolProfileFK = schools.First().Id
                },
                new EducationStudentProfile()
                {
                    FullName = "Radúz Casper Parris",
                    DateOfBirth = new DateTime(2011,05,05),
                    NSN = "10001",
                    Gender = "M",
                    EducationSchoolProfileFK = schools.Last().Id
                },
                new EducationStudentProfile()
                {
                    FullName = "Slava Tine Alan",
                    DateOfBirth = new DateTime(2011,05,05),
                    NSN = "10003",
                    Gender = "M",
                    EducationSchoolProfileFK = schools.First().Id
                },
                new EducationStudentProfile()
                {
                    FullName = "Shenandoah Annika Dibra",
                    DateOfBirth = new DateTime(2011,05,05),
                    NSN = "10004",
                    Gender = "M",
                    EducationSchoolProfileFK = schools.Last().Id
                },
                new EducationStudentProfile()
                {
                    FullName = "Samuil Daniel Brennan",
                    DateOfBirth = new DateTime(2011,05,05),
                    NSN = "10005",
                    Gender = "M",
                    EducationSchoolProfileFK = schools.First().Id
                },
                new EducationStudentProfile()
                {
                    FullName = "Loreto Michelle Cloet",
                    DateOfBirth = new DateTime(2011,05,05),
                    NSN = "10006",
                    Gender = "F",
                    EducationSchoolProfileFK = schools.First().Id
                },
            };

            AddOrUpdateList(_repositoryService, list);
        }

        protected override void AddOrUpdateList(IExtractRepositoryService repositoryService, IList<EducationStudentProfile> entityList)
        {
            _repositoryService.AddOrUpdateList(entityList);
            //throw new NotImplementedException();
        }
    }
}
