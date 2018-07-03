using System;
using System.Collections.Generic;
using System.Linq;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Entities;
using App.Module32.Infrastructure.Constants.Db;
using App.Module32.Infrastructure.Utility;
using App.Module32.Shared.Models.Entities;
using App.Module32.Shared.Models.Enums;
using App.Module32.Shared.Models.Messages.API.V0100;

namespace App.Module32.Application.Services.Implementations
{
    public class StudentSearchService : IStudentSearchService
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private string _dbContextIdentifier = AppModuleDbContextNames.Default;

        public StudentSearchService(
            IDiagnosticsTracingService diagnosticsTracingService,
            IRepositoryService repositoryService
            )
        {
            _diagnosticsTracingService = diagnosticsTracingService;
            _repositoryService = repositoryService;
        }


        public StudentTransportDto FindStudent(StudentTransportSearchDto transportSearch)
        {
            if (transportSearch == null) { throw new ArgumentNullException($"Details have not been correctly filled out"); }
            if (!transportSearch.DateOfBirth.HasValue || string.IsNullOrWhiteSpace(transportSearch.StudentName)) { throw new ArgumentException("Student details have not been correctly filled out");}
            if (!transportSearch.SchoolId.HasValue && string.IsNullOrWhiteSpace(transportSearch.SchoolName)) { throw new ArgumentException("School details have not been correctly filled out"); }

            StudentExistEnum exist = StudentExistEnum.NotEnrolled;

            var listOfMatchedNames = GetNameMatchedStudentProfiles(transportSearch);
            _diagnosticsTracingService.Trace(TraceLevel.Debug, $"Students Found : {listOfMatchedNames.Count}");
            if (listOfMatchedNames.Count > 0)
            {
                exist = DoesSchoolExist(listOfMatchedNames, transportSearch)
                    ? StudentExistEnum.EnrolledAtSchool
                    : StudentExistEnum.Enrolled;
            }
            
            return new StudentTransportDto()
            {
                StudentExist = exist
            };
        }


        public IList<EducationStudentProfile> GetNameMatchedStudentProfiles(StudentTransportSearchDto transportSearch)
        {
            var dateOfBirthStudents = GetDbEducationStudentProfiles().Where(x => x.DateOfBirth == transportSearch.DateOfBirth.Value);

            var acceptableList = new List<EducationStudentProfile>();

            foreach (var student in dateOfBirthStudents)
            {
                var distance = CalculateDistanceForStudent(transportSearch, student);
                if (distance <= 2)
                {
                    acceptableList.Add(student);
                }
            }

            return acceptableList;
        }


        public int CalculateDistanceForStudent(StudentTransportSearchDto transportSearch, EducationStudentProfile student)
        {
            var studentNameSplit = student.FullName.Trim().Split(' ');
            var searchNameSplit = transportSearch.StudentName.Trim().Split(' ');
            int countDifferences = 0;
            if (studentNameSplit.Length != searchNameSplit.Length) { return Int32.MaxValue;} // Probably not the same person no?
            foreach (var searchName in searchNameSplit) // double for loop but names shouldn't really be longer than 5, Eh.. not great still, but for now
            {
                var array = new HashSet<int>();
                foreach (var studentName in studentNameSplit)
                {
                    array.Add(LevenshteinDistance.Compute(studentName, searchName));
                }

                countDifferences += array.Min();
            }

            return countDifferences;
        }

        public bool DoesSchoolExist(IList<EducationStudentProfile> studentProfiles, StudentTransportSearchDto transportSearch)
        {
            if (studentProfiles == null || !studentProfiles.Any()) { return false; }

            var school = GetSchool(transportSearch);
            if (school == null)
            {
                _diagnosticsTracingService.Trace(TraceLevel.Debug, $"School Not Found Id : {transportSearch.SchoolId}, Name : {transportSearch.SchoolName}");
                return false;
            }

            foreach (var student in studentProfiles)
            {
                if (student.EducationSchoolProfileFK == school.Id)
                {
                    _diagnosticsTracingService.Trace(TraceLevel.Debug, $"SchoolFound Id : {school.SchoolId}, Name : {school.Name}, Student : {student.Id}");
                    return true;
                }
            }
            _diagnosticsTracingService.Trace(TraceLevel.Debug, $"No Student Match Found Id : {school.SchoolId}, Name : {school.Name}");
            return false;
        }

        private EducationSchoolProfile GetSchool(StudentTransportSearchDto transportSearch)
        {
            var query = GetEducationSchoolProfiles();
            return transportSearch.SchoolId.HasValue ?
                query.FirstOrDefault(x => x.SchoolId == transportSearch.SchoolId) :
                query.FirstOrDefault(x => x.Name == transportSearch.SchoolName);
        }

        private IQueryable<EducationSchoolProfile> GetEducationSchoolProfiles()
        {
            return _repositoryService.GetQueryableSet<EducationSchoolProfile>(_dbContextIdentifier)
                .Where(x => x.RecordState == RecordPersistenceState.Active);
        }


        private IQueryable<EducationStudentProfile> GetDbEducationStudentProfiles()
        {
            return _repositoryService.GetQueryableSet<EducationStudentProfile>(_dbContextIdentifier)
                .Where(x => x.RecordState == RecordPersistenceState.Active);
        }

    }
}
