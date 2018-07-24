using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Module32.Infrastructure.Services.Interfaces.Extract;
using App.Module32.Shared.Models.Entities;
using AutoMapper;

namespace App.Module32.Infrastructure.Services.Implementations.Extract.Repositories
{
    public class StudentExtractRepositoryService : ExtractRepositoryService<EducationStudentProfile>, IStudentExtractRepositoryService
    {
        public StudentExtractRepositoryService(IDiagnosticsTracingService diagnosticsTracingService, IBatchRepositoryService repositoryService) 
            : base(diagnosticsTracingService, repositoryService)
        {
        }

        public override IQueryable<EducationStudentProfile> GetFilteredExistingData(IList<EducationStudentProfile> list)
        {
            if (list == null || !list.Any()) { return new List<EducationStudentProfile>().AsQueryable(); }
            var idList = list.Select(x => x.NSN);
            return RepositoryService.GetQueryableSet<EducationStudentProfile>(DbKey)
                .Where(p => idList.Contains(p.NSN)).AsNoTracking();
            ;
        }


        protected override void AddOrUpdateListThrottled(IList<EducationStudentProfile> list)
        {
            var exisitngItemsLookup = GetFilteredExistingData(list).ToDictionary(x => x.NSN, x => x);
            var updateList = new List<EducationStudentProfile>();
            var addList = new List<EducationStudentProfile>();
            foreach (var model in list)
            {
                if (exisitngItemsLookup.TryGetValue(model.NSN, out EducationStudentProfile existingItem))
                {
                    if (model.SourceModifiedDate >= existingItem.SourceModifiedDate) //TODO REMOVE =
                    {
                        Mapper.Map<EducationStudentProfile, EducationStudentProfile>(model, existingItem);
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


        protected override void CommitResults(IList<EducationStudentProfile> addList, IList<EducationStudentProfile> updateList)
        {
            if (addList != null && addList.Any())
            {
                var removedDuplicateAddList = addList
                    .GroupBy(x => x.NSN)
                    .Select(x => x.OrderByDescending(y => y.SourceModifiedDate).FirstOrDefault());
                RepositoryService.InsertAll(removedDuplicateAddList);
            }

            if (updateList != null && updateList.Any())
            {
                var removedDuplicateupdateList = updateList
                    .GroupBy(x => x.NSN)
                    .Select(x => x.OrderByDescending(y => y.SourceModifiedDate).FirstOrDefault());
                RepositoryService.UpdateAll(removedDuplicateupdateList, x => x.ColumnsToUpdate(
                    c => c.FullName,
                    c => c.Gender,
                    c => c.EducationSchoolProfileFK,
                    c => c.DateOfBirth,
                    c => c.SourceModifiedDate,
                    c => c.LastModifiedOnUtc,
                    c => c.LastModifiedByPrincipalId
                ));
            }

        }

    }
}
