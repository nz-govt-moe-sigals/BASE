using System;
using System.Collections.Generic;
using System.Linq;
using App.Core.Infrastructure.Services;
using App.Module32.Infrastructure.Services.Implementations.Base;
using App.Module32.Infrastructure.Services.Interfaces.Extract;
using App.Module32.Shared.Models.Entities;
using App.Module32.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module32.Infrastructure.Services.Implementations.Extract.DataServices
{
    public class StudentProfilesExtractService : BaseExtractService<StudentProfile, EducationStudentProfile>
    {
        private readonly ISchoolExtractRepositoryService _schoolExtractRepository;

        public StudentProfilesExtractService(IDiagnosticsTracingService tracingService, IStudentExtractAzureDocumentDbService documentDbService, 
            IStudentExtractRepositoryService repositoryService, ISchoolExtractRepositoryService schoolExtractRepository) 
            : base(tracingService, documentDbService, repositoryService)
        {
            _schoolExtractRepository = schoolExtractRepository;

        }



        public override List<EducationStudentProfile> CreateEntities(IList<StudentProfile> list)
        {
            var schools = _schoolExtractRepository.GetFilteredExistingData(list.Select(x => x.SchoolId))
                .ToDictionary(x => x.SchoolId, x => x);
            var entityList = new List<EducationStudentProfile>();
            foreach (var item in list) 
            {
                try
                {
                    var mappedItem = MapLocalDataToEntity(item);
                    if (!schools.TryGetValue(item.SchoolId, out EducationSchoolProfile school))
                    {
                        //HandleConversionException("Cannot Find school", item);
                        //continue;
                        mappedItem.EducationSchoolProfileFK = Guid.Parse("AF91D09A-3A67-39E8-6FE3-39E7D6F1984E"); // TODO get rid of need this  
                    }
                    else
                    {
                        mappedItem.EducationSchoolProfileFK = school.Id;
                    }

                    entityList.Add(mappedItem);
                }
                catch (Exception e)
                {
                    HandleConversionException(e, item);
                }
            }

            return entityList;
        }

        public override EducationStudentProfile MapLocalDataToEntity(StudentProfile item)
        {
            return Mapper.Map<StudentProfile, EducationStudentProfile>(item);
        }



    }
}
