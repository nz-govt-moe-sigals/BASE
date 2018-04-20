using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Module3.Infrastructure.Services.Implementations.Configuration;
using App.Module3.Shared.Models.Entities;

namespace App.Module3.Infrastructure.Services.Implementations.Extract
{
    public class ExtractRepositoryService : IExtractRepositoryService
    {
        private string _dbKey = Constants.Db.AppModule3DbContextNames.Module3;
        private readonly IRepositoryService _repositoryService;
        private readonly ExtractCachedRepoObject _repoObject;

        public ExtractRepositoryService(ExtractCachedRepoObject repoObject, IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
            _repoObject = repoObject ?? new ExtractCachedRepoObject();
        }


        public ExtractWatermark GetWaterMarkTimestamp(string sourceTableName)
        {
            return _repositoryService.GetSingle<ExtractWatermark>(_dbKey, x => x.SourceTableName == sourceTableName);
        }

        public void UpdateWaterMarkTimeStamp(ExtractWatermark watermark)
        {
            _repositoryService.AddOrUpdate<ExtractWatermark>(_dbKey, x => x.SourceTableName, watermark);
        }

        public IDictionary<string, AreaUnit> GetAreaUnits()
        {
            if (_repoObject.AreaUnitsLookup == null)
            {
                _repoObject.AreaUnitsLookup = _repositoryService.GetQueryableSet<AreaUnit>(_dbKey)
                    .ToDictionary(x => x.FIRSTKey, x => x);
            }
            return _repoObject.AreaUnitsLookup;
        }

        //Hmmm probably should make this baseReference but ontodo list;
        public void AddAreaUnit(AreaUnit newAreaUnit)
        {
            GetAreaUnits().Add(newAreaUnit.FIRSTKey, newAreaUnit); 
            AddOnCommit(newAreaUnit);
        }

        public void UpdateAreaUnit(AreaUnit exisitingAreaUnit, AreaUnit newAreaUnit)
        {
            exisitingAreaUnit.Text = newAreaUnit.Text;
            UpdateOnCommit(exisitingAreaUnit);
        }


        private void AddOnCommit<TModel>(TModel model) where TModel : class
        {
            _repositoryService.AddOnCommit(_dbKey, model);
        }

        private void UpdateOnCommit<TModel>(TModel model) where TModel : class
        {
            _repositoryService.UpdateOnCommit(_dbKey, model);
        }

    }
}
