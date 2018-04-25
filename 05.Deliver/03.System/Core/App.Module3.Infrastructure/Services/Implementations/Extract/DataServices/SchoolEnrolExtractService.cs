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
    public class SchoolEnrolExtractService : BaseDataExtractServices<SchoolEnrol>
    {
        public SchoolEnrolExtractService(BaseExtractServiceConfiguration configuration, IExtractRepositoryService reposorityService, IExtractAzureDocumentDbService documentDbService)
            : base(configuration, reposorityService, documentDbService)
        {

        }

        public override void UpdateLocalData(SchoolEnrol item)
        {
            var mappedEntity = Mapper.Map<SchoolEnrol, EducationProviderEnrolmentCount>(item);
            var educationProviderProfile = _repositoryService.GetEducationProviderProfile(item.SchoolId.ToString());
            mappedEntity.EducationProviderFK = educationProviderProfile.Id;
            _repositoryService.AddOrUpdate(mappedEntity);

        }
    }
}
