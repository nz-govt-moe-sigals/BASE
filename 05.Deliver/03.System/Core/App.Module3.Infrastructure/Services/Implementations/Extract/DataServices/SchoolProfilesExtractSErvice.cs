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
    public class SchoolProfilesExtractService : BaseExtractService<SchoolProfile>
    {
        public SchoolProfilesExtractService(BaseExtractServiceConfiguration configuration, IExtractRepositoryService reposorityService, IExtractAzureDocumentDbService documentDbService)
            : base(configuration, reposorityService, documentDbService)
        {

        }

        public override void UpdateLocalData(SchoolProfile item)
        {
            var mappedEntity = Mapper.Map<SchoolProfile, EducationProviderProfile>(item);
            mappedEntity.AreaUnitFK = LookUp<AreaUnit>(item.AreaUnitCode);
            mappedEntity.AuthorityTypeFK = LookUp<AuthorityType>(item.AuthorityCode);
            mappedEntity.SchoolingGenderFK = LookUp<EducationProviderGender>(item.CoEdStatusCode);
            //mappedEntity.CoLFK = NullableLookUp<AreaUnit>(item.ColId);
            mappedEntity.CommunityBoardFK = LookUp<CommunityBoard>(item.CommunityBoardCode);
            mappedEntity.RegionFK = LookUp<Region>(item.EducationRegionCode);
            mappedEntity.GeneralElectorateFK = LookUp<GeneralElectorate>(item.GeneralElectorateCode);
            //mappedEntity.LocalOfficeFK = NullableLookUp<LocalOffice>(item.LocalOfficeId);
            mappedEntity.MaoriElectorateFK = LookUp<MaoriElectorate>(item.MaoriElectorateCode);
            mappedEntity.StatusFK = LookUp<EducationProviderStatus>(item.OrgStatus);
            mappedEntity.TypeFK = LookUp<EducationProviderType>(item.OrgType);
            mappedEntity.RegionalCouncilFK = LookUp<RegionalCouncil>(item.RegionalCouncilCode);
            mappedEntity.EducationProviderTypeFK = NullableLookUp<EducationProviderType>(item.SchoolClassificationCode);
            mappedEntity.SpecialSchoolingFK = NullableLookUp<SpecialSchooling>(item.SpecialSchoolingCode);
            mappedEntity.TeacherEducationFK = NullableLookUp<TeacherEducation>(item.TeacherEducationCode);
            mappedEntity.TerritorialAuthorityFK = LookUp<TerritorialAuthority>(item.TerritorialAuthorityCode);
            mappedEntity.UrbanAreaFK = LookUp<UrbanArea>(item.UrbanAreaCode);
            mappedEntity.WardFK = LookUp<Ward>(item.WardCode);

            _repositoryService.AddOrUpdateEducationProfile(mappedEntity);
          
        }



        public Guid LookUp<T>(string code)
            where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase
        {
            var value = NullableLookUp<T>(code);
            if (value.HasValue)
            {
                return value.Value;
            }
            throw new ArgumentException($"code : {code} not found for type : {typeof(T)}");
        }

        public Guid? NullableLookUp<T>(string code)
            where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase
        {
            if (string.IsNullOrWhiteSpace(code)) { return null; }
            var areaUnitsLookup = _repositoryService.GetSifCachedData<T>();
            if (areaUnitsLookup.TryGetValue(code, out var existingEntity))
            {
                return existingEntity.Id;
            }
            throw new ArgumentException($"code : {code} not found for type : {typeof(T)}");
        }


    }
}
