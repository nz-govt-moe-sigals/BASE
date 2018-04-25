using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Module3.Infrastructure.Services.Configuration;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module3.Infrastructure.Services.Implementations.Extract.DataServices
{
    public class SchoolLevelGenderExtractService : BaseDataExtractServices<SchoolLevelGender>
    {
        public SchoolLevelGenderExtractService(BaseExtractServiceConfiguration configuration, IExtractRepositoryService reposorityService, IExtractAzureDocumentDbService documentDbService)
            : base(configuration, reposorityService, documentDbService)
        {

        }

        public override void UpdateLocalData(SchoolLevelGender item)
        {
            var mappedEntity = Mapper.Map<SchoolLevelGender, EducationProviderLevelGender>(item);
            var educationProviderProfile = _repositoryService.GetEducationProviderProfile(item.SchoolId.ToString());
            mappedEntity.EducationProviderFK = educationProviderProfile.Id;
            mappedEntity.GenderFK = LookUp<EducationProviderGender>(item.GenderValueId);
            mappedEntity.YearFK = LookUp<EducationProviderYearLevel>(item.YearValueId);
            _repositoryService.AddOrUpdate(mappedEntity);
            //_repositoryService.UpdateOnCommit(_dbKey, );
            // Some Sky Magic Code
        }
    }
}
