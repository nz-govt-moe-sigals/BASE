using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Module3.Shared.Models.Entities;

namespace App.Module3.Infrastructure.Services.Implementations.Configuration
{
    public class ExtractCachedRepoObject
    {
        private readonly ConcurrentDictionary<Type, ConcurrentDictionary<string, SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase>> _lookDictionary;
        


        public ExtractCachedRepoObject()
        {
            _lookDictionary = new ConcurrentDictionary<Type, ConcurrentDictionary<string, SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase>>();
            EducationProviderProfiles = new ConcurrentDictionary<string, EducationProviderProfile>();
        }

        public ConcurrentDictionary<string, SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase> GetCachedLookUpData<T>()
        {
            if(_lookDictionary.TryGetValue(typeof(T), out var existingEntity))
            {
                return existingEntity;
            }
            return null;
        }

        public void CacheLookUpData<T>(ConcurrentDictionary<string, SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase> dic)
        {
            _lookDictionary.TryAdd(typeof(T), dic);
        }


        public ConcurrentDictionary<string, EducationProviderProfile> EducationProviderProfiles { get; set; }
        /*
        public IDictionary<string, AreaUnit> AreaUnitsLookup { get; set; }

        public IDictionary<string, AuthorityType> AuthorityTypeLookup { get; set; }

        public IDictionary<string, CommunityBoard> CommunityBoardLookup { get; set; }

        public IDictionary<string, GeneralElectorate> GeneralElectorateLookup { get; set; }

        public IDictionary<string, MaoriElectorate> MaoriElectorateLookup { get; set; }

        public IDictionary<string, EducationProviderStatus> EducationProviderStatusLookup { get; set; }

        public IDictionary<string, EducationProviderType> EducationProviderTypeLookup { get; set; }

        public IDictionary<string, RegionalCouncil> RegionalCouncilLookup { get; set; }

        public IDictionary<string, Region> RegionLookup { get; set; }

        public IDictionary<string, RelationshipType> RelationshipTypeLookup { get; set; }

        public IDictionary<string, EducationProviderClassification> EducationProviderClassificationLookup { get; set; }

        public IDictionary<string, EducationProviderGender> EducationProviderGenderLookup { get; set; }

        public IDictionary<string, EducationProviderYearLevel> EducationProviderYearLookup { get; set; }

        public IDictionary<string, SpecialSchooling> SpecialSchoolingLookup { get; set; }

        public IDictionary<string, TeacherEducation> TeacherEducationLookup { get; set; }

        public IDictionary<string, TerritorialAuthority> TerritorialAuthorityLookup { get; set; }

        public IDictionary<string, UrbanArea> UrbanAreaLookup { get; set; }

        public IDictionary<string, Ward> WardLookup { get; set; }
        */
    }
}
