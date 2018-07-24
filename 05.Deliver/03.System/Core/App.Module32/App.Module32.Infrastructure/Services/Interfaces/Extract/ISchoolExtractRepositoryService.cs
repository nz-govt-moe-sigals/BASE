

using System.Collections.Generic;
using System.Linq;
using App.Module32.Shared.Models.Entities;

namespace App.Module32.Infrastructure.Services.Interfaces.Extract
{
    public interface ISchoolExtractRepositoryService : IExtractRepositoryService<EducationSchoolProfile>
    {
        IQueryable<EducationSchoolProfile> GetFilteredExistingData(IEnumerable<int> schoolIdList);
    }
}
