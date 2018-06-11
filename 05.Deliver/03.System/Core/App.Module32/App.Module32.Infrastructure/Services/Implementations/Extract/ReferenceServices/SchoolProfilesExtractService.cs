using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Module32.Infrastructure.Services.Implementations.Base;
using App.Module32.Shared.Models.Entities;
using App.Module32.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module32.Infrastructure.Services.Implementations.Extract.ReferenceServices
{
    public class SchoolProfilesExtractService :  BaseExtractService<SchoolProfile>
    {
        public SchoolProfilesExtractService(IDiagnosticsTracingService tracingService, IExtractAzureDocumentDbService documentDbService, IExtractRepositoryService repositoryService) 
            : base(tracingService, documentDbService, repositoryService)
        {
        }

        /// <summary>
        /// returns a list of 
        /// </summary>
        /// <param name="watermark">Get data after this point</param>
        /// <returns></returns>
        protected override async Task<IList<SchoolProfile>> GetDataToUpdateAsync(DateTime watermark)
        {
            // connnect to document DB and retrieve data
            // timestamp should be Greater thjan the watermark gotten from  the DB
            var queryable = base.GetDataQueryToUpdateAsync(watermark);
                    
            return (await queryable)
                .GroupBy(x => x.SchoolId)
                .Select(x => x.OrderByDescending(y => y.ModifiedDate).FirstOrDefault())
                .ToList();
        }

        public override void UpdateLocalData(IExtractRepositoryService repositoryService, SchoolProfile item)
        {
            var mappedEntity = Mapper.Map<SchoolProfile, EducationSchoolProfile>(item);
            repositoryService.AddOrUpdate(mappedEntity);
        }


    }
}
