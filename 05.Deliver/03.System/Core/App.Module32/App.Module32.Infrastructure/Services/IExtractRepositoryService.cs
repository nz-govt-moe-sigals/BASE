
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Module32.Shared.Models.Entities;

namespace App.Module32.Infrastructure.Services
{
    public interface IExtractRepositoryService
    {
        ExtractWatermark GetWaterMarkTimestamp(string sourceTableName);

        void UpdateWaterMarkTimeStamp(ExtractWatermark watermark);


        IQueryable<EducationSchoolProfile> GetEducationSchoolProfiles(IList<EducationSchoolProfile> list);


        void CommitResults();

        void AddOrUpdateList(IList<EducationSchoolProfile> list);

        void AddOrUpdateList(IList<EducationStudentProfile> list);

    }
}





