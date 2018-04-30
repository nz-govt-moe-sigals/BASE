
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using App.Core.Infrastructure.Services;
 using App.Module3.Infrastructure.Services.Configuration;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module3.Infrastructure.Services.Implementations.Extract.DataServices
{
    public class SchoolProfilesExtractService : BaseDataExtractServices<SchoolProfile>
    {
        public SchoolProfilesExtractService(BaseExtractServiceConfiguration configuration, IDiagnosticsTracingService tracingService, IExtractAzureDocumentDbService documentDbService)
            : base(configuration, tracingService, documentDbService)
        {

        }


        
        private async Task Test(IExtractRepositoryService repositoryService, IList<SchoolProfile> list)
        {
          
            //UpdateLocalData(repositoryService, list.First());
            
            await Task.WhenAll(list.Select((item) => Task.Run(() => UpdateLocalData(repositoryService, item))));
        }

        public override void UpdateLocalData(IExtractRepositoryService repositoryService, SchoolProfile item)
        {
            var mappedEntity = Mapper.Map<SchoolProfile, EducationProviderProfile>(item);
            mappedEntity.AreaUnitFK = NullableLookUp<AreaUnit>(repositoryService, item.AreaUnitCode);
            mappedEntity.AuthorityTypeFK = LookUp<AuthorityType>(repositoryService, item.AuthorityCode);
            //mappedEntity.SchoolingGenderFK = LookUp<EducationProviderGender>(item.CoEdStatusCode); //CURRENTLY DATA Comes through as a Text not a code
            //mappedEntity.CoLFK = NullableLookUp<AreaUnit>(item.ColId); // Do Not have a Reference Table
            mappedEntity.CommunityBoardFK = NullableLookUp<CommunityBoard>(repositoryService, item.CommunityBoardCode);
            mappedEntity.RegionFK = LookUp<Region>(repositoryService, item.EducationRegionCode);
            mappedEntity.GeneralElectorateFK = NullableLookUp<GeneralElectorate>(repositoryService, item.GeneralElectorateCode);
            //mappedEntity.LocalOfficeFK = NullableLookUp<LocalOffice>(item.LocalOfficeId); // Do Not have a Reference Table
            mappedEntity.MaoriElectorateFK = NullableLookUp<MaoriElectorate>(repositoryService, item.MaoriElectorateCode);
            mappedEntity.StatusFK = LookUp<EducationProviderStatus>(repositoryService, item.OrgStatus);
            mappedEntity.EducationProviderTypeFK = LookUp<EducationProviderType>(repositoryService, item.OrgType);
            mappedEntity.RegionalCouncilFK = NullableLookUp<RegionalCouncil>(repositoryService, item.RegionalCouncilCode);
            mappedEntity.ClassificationFK = NullableLookUp<EducationProviderClassification>(repositoryService, item.SchoolClassificationCode);
            mappedEntity.SpecialSchoolingFK = NullableLookUp<SpecialSchooling>(repositoryService, item.SpecialSchoolingCode);
            mappedEntity.TeacherEducationFK = NullableLookUp<TeacherEducation>(repositoryService, item.TeacherEducationCode);
            mappedEntity.TerritorialAuthorityFK = NullableLookUp<TerritorialAuthority>(repositoryService, item.TerritorialAuthorityCode);
            mappedEntity.UrbanAreaFK = NullableLookUp<UrbanArea>(repositoryService, item.UrbanAreaCode);
            mappedEntity.WardFK = NullableLookUp<Ward>(repositoryService, item.WardCode);

            repositoryService.AddOrUpdateEducationProfile(mappedEntity);

        }






    }
}

