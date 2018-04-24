using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Shared.Models.Entities
{
    using System.Collections.ObjectModel;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Entities.Base;
    using App.Module3.Shared.Models.Messages.Extract;

    public class EducationProviderProfile : TenantFKTimestampedAuditedRecordStatedGuidIdEntityBase, IHasName, IHasSourceSystemKey
    {


        // ---------------------

        public Guid TypeFK
        {
            get; set;
        }
        public EducationProviderType Type
        {
            get; set;
        }


        public Guid StatusFK
        {
            get; set;
        }
        public EducationProviderStatus Status
        {
            get; set;
        }


        public Guid SchoolingGenderFK
        {
            get; set;
        }
        public EducationProviderGender SchoolingGender
        {
            get; set;
        }

        public Guid LocalOfficeFK
        {
            get; set;
        }
        public LocalOffice LocalOffice
        {
            get; set;
        }


        public int? Decile
        {
            get; set;
        }

        public Guid? CoLFK
        {
            get; set;
        }
        public CoL CoL
        {
            get; set;
        }

        public Guid AuthorityTypeFK
        {
            get; set;
        }
        public AuthorityType AuthorityType
        {
            get; set;
        }



        public Guid AreaUnitFK
        {
            get; set;
        }
        public AreaUnit AreaUnit
        {
            get; set;
        }


        public Guid CommunityBoardFK
        {
            get; set;
        }
        public CommunityBoard CommunityBoard
        {
            get; set;
        }


        public Guid GeneralElectorateFK
        {
            get; set;
        }
        public MaoriElectorate GeneralElectorate
        {
            get; set;
        }


        public Guid MaoriElectorateFK
        {
            get; set;
        }
        public MaoriElectorate MaoriElectorate
        {
            get; set;
        }


        public Guid RegionalCouncilFK
        {
            get; set;
        }

        public UrbanArea RegionalCouncil
        {
            get; set;
        }

        public Guid EducationProviderTypeFK
        {
            get; set;
        }

        public EducationProviderType EducationProviderType
        {
            get; set;
        }
        public Guid RegionFK
        {
            get; set;
        }
        public Region Region
        {
            get; set;
        }


        public Guid SpecialSchoolingFK
        {
            get; set;
        }

        public SpecialSchooling SpecialSchooling
        {
            get; set;
        }



        public Guid TeacherEducationFK
        {
            get; set;
        }

        public TeacherEducation TeacherEducation
        {
            get; set;
        }

        public Guid TerritorialAuthorityFK
        {
            get; set;
        }
        public UrbanArea TerritorialAuthority
        {
            get; set;
        }


        public Guid UrbanAreaFK
        {
            get; set;
        }
        public UrbanArea UrbanArea
        {
            get; set;
        }


        public Guid WardFK
        {
            get; set;
        }

        public Ward Ward
        {
            get; set;
        }

        // ---------------------


        public virtual ICollection<EducationProviderLocation> Locations
        {
            get
            {
                return _locations ?? (_locations = new Collection<EducationProviderLocation>());
            }
            //set => _levelGender = value;
        }
        private ICollection<EducationProviderLocation> _locations;





        // ---------------------

        public virtual ICollection<EducationProviderLevelGender> LevelGender
        {
            get
            {
                return _levelGender ?? (_levelGender = new Collection<EducationProviderLevelGender>());
            }
            //set => _levelGender = value;
        }
        private ICollection<EducationProviderLevelGender> _levelGender;




        public virtual ICollection<EducationProviderEnrolmentCount> RollCounts
        {
            get { return this._rollCount ?? (this._rollCount = new Collection<EducationProviderEnrolmentCount>()); }
        }
        private ICollection<EducationProviderEnrolmentCount> _rollCount;

        // ---------------------

        /// <summary>
        /// Gets or sets the school identifier.
        /// <para>
        /// Note: it's not SchoolFK, because there is no table to match.
        /// </para>
        /// </summary>
        public int SchoolId
        {
            get; set;
        }

        public string Name
        {
            get;
            set;
        }

        public DateTimeOffset? OpeningDate
        {
            get; set;
        }

        public DateTimeOffset? ClosedDate
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public string Telephone
        {
            get; set;
        }
        public string Fax
        {
            get; set;
        }

        public bool? CohortEntryCurrent
        {
            get; set;
        }

        public bool? CohortEntryFuture
        {
            get; set;
        }
        public DateTime? CohortEntryFutureFrom
        {
            get; set;
        }


        public string Url
        {
            get; set;
        }

        // ---------------------

        public string Address1Line1
        {
            get; set;
        }
        public string Address1Line2
        {
            get; set;
        }
        public string Address1Line3
        {
            get; set;
        }
        public string Address1Suburb
        {
            get; set;
        }
        public string Address1City
        {
            get; set;
        }
        public string Address1PostalCode
        {
            get; set;
        }


        // ---------------------


        public string Address2Line1
        {
            get; set;
        }
        public string Address2Line2
        {
            get; set;
        }
        public string Address2Line3
        {
            get; set;
        }
        public string Address2Suburb
        {
            get; set;
        }
        public string Address2City
        {
            get; set;
        }
        public string Address2PostalCode
        {
            get; set;
        }

        // ---------------------

        public string Contact1Name
        {
            get; set;
        }
        public string Contact1Role
        {
            get; set;
        }
        public string Contact2Name
        {
            get; set;
        }
        public string Contact2Role
        {
            get; set;
        }
        // ---------------------

        /// <summary>
        /// The Reference(record) Id that was received from the source 
        /// </summary>
        public string SourceSystemKey { get; set; }

        public string SourceSystemName { get; set; }
    }
}
