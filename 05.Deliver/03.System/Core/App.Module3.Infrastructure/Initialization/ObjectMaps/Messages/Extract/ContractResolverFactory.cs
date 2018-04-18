using App.Module3.Shared.Models.Messages.Extract;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Messages.Extract
{
    public static class ContractResolverFactory
    {
        private static Dictionary<Type, IContractResolver> _dictionary;

        static ContractResolverFactory()
        {
            _dictionary = new Dictionary<Type, IContractResolver>();
            _dictionary.Add(typeof(ReferenceAreaUnits), new ContractResolverReferenceAreaUnits());
            _dictionary.Add(typeof(ReferenceAuthorityType), new ContractResolverReferenceAuthorityType());
            _dictionary.Add(typeof(ReferenceCommunityBoard), new ContractResolverReferenceCommunityBoard());
            _dictionary.Add(typeof(ReferenceGeneralElectorate), new ContractResolverReferenceGeneralElectorate());
            _dictionary.Add(typeof(ReferenceMaoriElectorate), new ContractResolverReferenceMaoriElectorate());
            _dictionary.Add(typeof(ReferenceOrganisationStatus), new ContractResolverReferenceOrganisationStatus());
            _dictionary.Add(typeof(ReferenceOrganisationType), new ContractResolverReferenceOrganisationType());
            _dictionary.Add(typeof(ReferenceRegion), new ContractResolverReferenceRegion());
            _dictionary.Add(typeof(ReferenceRegionalCouncil), new ContractResolverReferenceRegionalCouncil());
            _dictionary.Add(typeof(ReferenceRelationshipType), new ContractResolverReferenceRelationshipType());
            _dictionary.Add(typeof(ReferenceSchoolClassification), new ContractResolverReferenceSchoolClassification());
            _dictionary.Add(typeof(ReferenceSchoolingGender), new ContractResolverReferenceSchoolingGender());
            _dictionary.Add(typeof(ReferenceSchoolYearLevel), new ContractResolverReferenceSchoolYearLevel());
            _dictionary.Add(typeof(ReferenceSpecialSchooling), new ContractResolverReferenceSpecialSchooling());
            _dictionary.Add(typeof(ReferenceTeacherEducation), new ContractResolverReferenceTeacherEducation());
            _dictionary.Add(typeof(ReferenceTerritorialAuthority), new ContractResolverReferenceTerritorialAuthority());
            _dictionary.Add(typeof(ReferenceUrbanArea), new ContractResolverReferenceUrbanArea());
            _dictionary.Add(typeof(ReferenceWard), new ContractResolverReferenceWard());
            _dictionary.Add(typeof(SchoolEnrol), new ContractResolverSchoolEnrol());
            _dictionary.Add(typeof(SchoolLevelGender), new ContractResolverSchoolLevelGender());
            _dictionary.Add(typeof(SchoolProfiles), new ContractResolverSchoolProfiles());
            _dictionary.Add(typeof(SchoolWGS), new ContractResolverSchoolWGS());
            _dictionary.Add(typeof(Summary), new ContractResolverSummary());

        }

        public static IContractResolver GetContractResolver<T>()
        {
            IContractResolver contractresolver;
            _dictionary.TryGetValue(typeof(T), out contractresolver);
            return contractresolver;
        }
    }
}
