using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using App.Core.Infrastructure.Services;
using App.Module32.Infrastructure.Services.Interfaces.Extract;
using App.Module32.Shared.Models.Entities;
using App.Module32.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module32.Infrastructure.Services.Implementations.Extract.Repositories
{
    public class SchoolExtractRepositoryService : ExtractRepositoryService<EducationSchoolProfile>, ISchoolExtractRepositoryService
    {
        public SchoolExtractRepositoryService(IDiagnosticsTracingService diagnosticsTracingService, IBatchRepositoryService repositoryService) 
            : base(diagnosticsTracingService, repositoryService)
        {
        }


        public override IQueryable<EducationSchoolProfile> GetFilteredExistingData(IList<EducationSchoolProfile> list)
        {
            if (list == null || !list.Any()) { return new List<EducationSchoolProfile>().AsQueryable(); }
            var idList = list.Select(x => x.SchoolId);
            return GetFilteredExistingData(idList);
        }

        public IQueryable<EducationSchoolProfile> GetFilteredExistingData(IEnumerable<int> schoolIdList)
        {
            if (schoolIdList == null) { return new List<EducationSchoolProfile>().AsQueryable(); }
            return RepositoryService.GetQueryableSet<EducationSchoolProfile>(DbKey)
                .Where(p => schoolIdList.Contains(p.SchoolId)).AsNoTracking();
            ;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        protected override void AddOrUpdateListThrottled(IList<EducationSchoolProfile> list)
        {
            var exisitngItemsLookup = GetFilteredExistingData(list).ToDictionary(x => x.SchoolId, x => x);
            var updateList = new List<EducationSchoolProfile>();
            var addList = new List<EducationSchoolProfile>();
            foreach (var model in list)
            {
                if (exisitngItemsLookup.TryGetValue(model.SchoolId, out EducationSchoolProfile existingItem))
                {
                    if (model.SourceModifiedDate >= existingItem.SourceModifiedDate) //TODO REMOVE =
                    {
                        Mapper.Map<EducationSchoolProfile, EducationSchoolProfile>(model, existingItem);
                        RepositoryService.PreProcessEntity(existingItem);
                        updateList.Add(existingItem);
                    }
                }
                else
                {
                    RepositoryService.PreProcessEntity(model);
                    addList.Add(model);
                }
            }
            CommitResults(addList, updateList);
        }


        protected override void CommitResults(IList<EducationSchoolProfile> addList, IList<EducationSchoolProfile> updateList)
        {
            if (addList != null && addList.Any())
            {
                var removedDuplicateAddList = addList
                    .GroupBy(x => x.SchoolId)
                    .Select(x => x.OrderByDescending(y => y.SourceModifiedDate).FirstOrDefault());
                RepositoryService.InsertAll(removedDuplicateAddList);
            }

            if (updateList != null && updateList.Any())
            {
                var removedDuplicateupdateList = updateList
                    .GroupBy(x => x.SchoolId)
                    .Select(x => x.OrderByDescending(y => y.SourceModifiedDate).FirstOrDefault());
                RepositoryService.UpdateAll(removedDuplicateupdateList, x => x.ColumnsToUpdate(
                    c => c.Name,
                    c => c.SourceModifiedDate,
                    c => c.LastModifiedOnUtc,
                    c => c.LastModifiedByPrincipalId
                ));
            }

        }


    }
}
