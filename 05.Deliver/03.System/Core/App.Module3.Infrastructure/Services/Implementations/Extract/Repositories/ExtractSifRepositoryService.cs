using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using App.Module3.Shared.Models;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Entities.Sif;

namespace App.Module3.Infrastructure.Services.Implementations.Extract.Repositories
{
    public class ExtractSifRepositoryService : IExtractSifRepositoryService
    {
        private IEnumerable<SifCoEducationStatus> CoEducationStatus { get; set; }

        private IEnumerable<SifOrgranisationType> OrganisationType { get; set; }

        private IEnumerable<SifOrganisationStatus> OrganisationStatus { get; set; }

        private IEnumerable<SifEducationRegion> EducationRegion { get; set; }

        private IEnumerable<SifAuthorityType> AuthorityType { get; set; }

        private IEnumerable<SifSchoolClassification> SchoolClassification { get; set; }

        private IEnumerable<SifSpecialSchooling> SpecialSchooling { get; set; }

        private IEnumerable<SifSchoolTeacherEducation> SchoolTeacherEducation { get; set; }


        public ExtractSifRepositoryService()
        {
            InitCoEducationStatus();
            InitOrganisationType();
            InitOrganisationStatus();
            InitEducationRegion();
            InitAuthorityType();
            InitSchoolClassification();
            InitSpecialSchooling();
            InitSchoolTeacherEducation();
        }

        public TModel GetSingle<TModel>(string contextKey, Expression<Func<IHasSifSouceDataBase, bool>> filterPredicate) where TModel : class, IHasSifSouceDataBase
        {
            var type = typeof(TModel);
            if (type == typeof(SifCoEducationStatus))
            {
                return CoEducationStatus.AsQueryable().SingleOrDefault(filterPredicate) as TModel;
            }
            if (type == typeof(SifOrgranisationType))
            {
                return OrganisationType.AsQueryable().SingleOrDefault(filterPredicate) as TModel;
            }
            if (type == typeof(SifOrganisationStatus))
            {
                return OrganisationStatus.AsQueryable().SingleOrDefault(filterPredicate) as TModel;
            }
            if (type == typeof(SifEducationRegion))
            {
                return EducationRegion.AsQueryable().SingleOrDefault(filterPredicate) as TModel;
            }
            if (type == typeof(SifAuthorityType))
            {
                return AuthorityType.AsQueryable().SingleOrDefault(filterPredicate) as TModel;
            }
            if (type == typeof(SifSchoolClassification))
            {
                return SchoolClassification.AsQueryable().SingleOrDefault(filterPredicate) as TModel;
            }
            if (type == typeof(SifSpecialSchooling))
            {
                return SpecialSchooling.AsQueryable().SingleOrDefault(filterPredicate) as TModel;
            }
            if (type == typeof(SifSchoolTeacherEducation))
            {
                return SchoolTeacherEducation.AsQueryable().SingleOrDefault(filterPredicate) as TModel;
            }
            return null;
        }



        /// <summary>
        /// 2.4.3	Co-Education Status
        /// </summary>
        private void InitCoEducationStatus()
        {
            var list = new List<SifCoEducationStatus>()
            {
                new SifCoEducationStatus() { FirstId = "55000", EvaId = "C", SifId = "C"},
                new SifCoEducationStatus() { FirstId = "55001", EvaId = "F", SifId = "F"},
                new SifCoEducationStatus() { FirstId = "55002", EvaId = "M", SifId = "M"},
                new SifCoEducationStatus() { FirstId = "Unknown1", EvaId = "C1", SifId = "C2"}, // apparently doesnt have first 
                new SifCoEducationStatus() { FirstId = "Unknown2", EvaId = "C2", SifId = "C1"} //aparently dont have first
            };
            CoEducationStatus = list;
        }


        /// <summary>
        /// 2.4.4	Organisation Type
        /// </summary>
        private void InitOrganisationType()
        {
            var list = new List<SifOrgranisationType>()
            {
                new SifOrgranisationType() { FirstId = "Unknown1", EvaId = "1", SifId = "1"},// apparently doesnt have first 
                new SifOrgranisationType() { FirstId = "Unknown2", EvaId = "8", SifId = "8"},// apparently doesnt have first 
                new SifOrgranisationType() { FirstId = "Unknown3", EvaId = "9", SifId = "9"},// apparently doesnt have first 
                new SifOrgranisationType() { FirstId = "10030", EvaId = "2", SifId = "2"}, 
                new SifOrgranisationType() { FirstId = "10024", EvaId = "3", SifId = "3"}, 
                new SifOrgranisationType() { FirstId = "10031", EvaId = "4", SifId = "4"},
                new SifOrgranisationType() { FirstId = "10023", EvaId = "5", SifId = "5"},
                new SifOrgranisationType() { FirstId = "10025", EvaId = "6", SifId = "6"},
                new SifOrgranisationType() { FirstId = "10032", EvaId = "7", SifId = "7"}, 
                new SifOrgranisationType() { FirstId = "10029", EvaId = "10", SifId = "10"},
                new SifOrgranisationType() { FirstId = "10033", EvaId = "11", SifId = "11"},
                new SifOrgranisationType() { FirstId = "10026", EvaId = "12", SifId = "12"},
                new SifOrgranisationType() { FirstId = "10034", EvaId = "13", SifId = "13"},
                new SifOrgranisationType() { FirstId = "10036", EvaId = "14", SifId = "14"}
            };
            OrganisationType = list;
        }

        /// <summary>
        /// 2.4.5	Organisation Status
        /// </summary>
        private void InitOrganisationStatus()
        {
            var list = new List<SifOrganisationStatus>()
            {
                new SifOrganisationStatus() { FirstId = "28000", EvaId = "28000", SifId = "P"},
                new SifOrganisationStatus() { FirstId = "28001", EvaId = "28001", SifId = "O"},
                new SifOrganisationStatus() { FirstId = "28002", EvaId = "28002", SifId = "C"}
            };
            OrganisationStatus = list;
        }

        /// <summary>
        /// 2.4.6	Education Region
        /// </summary>
        private void InitEducationRegion()
        {
            var list = new List<SifEducationRegion>()
            {
                new SifEducationRegion() { FirstId = "12008", EvaId = "12008", SifId = "1"},
                new SifEducationRegion() { FirstId = "12010", EvaId = "12010", SifId = "2"},
                new SifEducationRegion() { FirstId = "12015", EvaId = "12015", SifId = "3"},
                new SifEducationRegion() { FirstId = "12012", EvaId = "12012", SifId = "4"},
                new SifEducationRegion() { FirstId = "12014", EvaId = "12014", SifId = "5"},
                new SifEducationRegion() { FirstId = "12016", EvaId = "12016", SifId = "6"},
                new SifEducationRegion() { FirstId = "12007", EvaId = "12007", SifId = "7"},
                new SifEducationRegion() { FirstId = "12011", EvaId = "12011", SifId = "8"},
                new SifEducationRegion() { FirstId = "12009", EvaId = "12009", SifId = "9"},
                new SifEducationRegion() { FirstId = "12013", EvaId = "12013", SifId = "10"}
            };
            EducationRegion = list;
        }

        /// <summary>
        /// 2.4.7	Authority Type
        /// </summary>
        private void InitAuthorityType()
        {
            var list = new List<SifAuthorityType>()
            {
                new SifAuthorityType() { FirstId = "42000", EvaId = "42000", SifId = "1"},
                //new SifAuthorityType() { FirstId = "42004", EvaId = "42000", SifId = "1"}, //no idea how i should even map this one?
                new SifAuthorityType() { FirstId = "42001", EvaId = "42001", SifId = "2"},
                new SifAuthorityType() { FirstId = "42002", EvaId = "42002", SifId = "3"},
                new SifAuthorityType() { FirstId = "42003", EvaId = "42003", SifId = "4"},
                //new SifAuthorityType() { FirstId = "42011", EvaId = "42011", SifId = ""}, // there is no Sif Code so just default back 
                new SifAuthorityType() { FirstId = "42012", EvaId = "42012", SifId = "6"}
            };
            AuthorityType = list;
        }


        /// <summary>
        /// 2.4.8	School Classification
        /// </summary>
        private void InitSchoolClassification()
        {
            var list = new List<SifSchoolClassification>()
            {
                new SifSchoolClassification() { FirstId = "52001", EvaId = "52001", SifId = "101"},
                new SifSchoolClassification() { FirstId = "52002", EvaId = "52002", SifId = "102"},
                new SifSchoolClassification() { FirstId = "52003", EvaId = "52003", SifId = "103"},
                new SifSchoolClassification() { FirstId = "52004", EvaId = "52004", SifId = "104"},
                new SifSchoolClassification() { FirstId = "52007", EvaId = "52007", SifId = "105"}, 
                new SifSchoolClassification() { FirstId = "52008", EvaId = "52008", SifId = "106"},
                new SifSchoolClassification() { FirstId = "52009", EvaId = "52009", SifId = "107"},
                new SifSchoolClassification() { FirstId = "52010", EvaId = "52010", SifId = "108"}
            };
            SchoolClassification = list;
        }

        /// <summary>
        /// 2.4.9	Special Schooling
        /// </summary>
        private void InitSpecialSchooling()
        {
            var list = new List<SifSpecialSchooling>()
            {
                new SifSpecialSchooling() { FirstId = "51000", EvaId = "51000", SifId = "201"},
                new SifSpecialSchooling() { FirstId = "51001", EvaId = "51001", SifId = "202"},
                new SifSpecialSchooling() { FirstId = "51002", EvaId = "51002", SifId = "203"},
                new SifSpecialSchooling() { FirstId = "51003", EvaId = "51003", SifId = "204"},
                new SifSpecialSchooling() { FirstId = "51004", EvaId = "51004", SifId = "205"},
                new SifSpecialSchooling() { FirstId = "51009", EvaId = "51009", SifId = "206"}
            };
            SpecialSchooling = list;
        }

        /// <summary>
        /// 2.4.10	Teacher Education
        /// </summary>
        private void InitSchoolTeacherEducation()
        {
            var list = new List<SifSchoolTeacherEducation>()
            {
                new SifSchoolTeacherEducation() { FirstId = "50000", EvaId = "50000", SifId = "301"},
                new SifSchoolTeacherEducation() { FirstId = "50001", EvaId = "50001", SifId = "302"},
                new SifSchoolTeacherEducation() { FirstId = "50002", EvaId = "50002", SifId = "303"}
            };
            SchoolTeacherEducation = list;
        }
    }
}
