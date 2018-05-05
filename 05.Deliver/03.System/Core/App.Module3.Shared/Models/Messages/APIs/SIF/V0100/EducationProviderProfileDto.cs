using System;

namespace App.Module3.Shared.Models.Messages.APIs.SIF.V0100
{
    using System.Collections.Generic;
    using App.Core.Shared.Factories;
    using App.Core.Shared.Models;
    using App.Module3.Shared.Models.Entities;
    using App.Module3.Shared.Models.Messages.APIs.V0100;

    public class EducationProviderDto : IHasId<string>
    {
        
        public string Id { get; set; }

        
        public EducationProviderClassificationTypeDto Classification
        {
            get; set;
        }


        public EducationProviderStatusDto Status
        {
            get; set;
        }


        public EducationProviderSchoolingGenderDto SchoolingGender
        {
            get; set;
        }

        public LocalOfficeDto LocalOffice
        {
            get; set;
        }


        public int? Decile
        {
            get; set;
        }

        public CoLDto CoL
        {
            get; set;
        }

        public AuthorityTypeDto AuthorityType
        {
            get; set;
        }



        public AreaUnitDto AreaUnit
        {
            get; set;
        }


        public CommunityBoardDto CommunityBoard
        {
            get; set;
        }


        public GeneralElectorateDto GeneralElectorate
        {
            get; set;
        }


        public MaoriElectorateDto MaoriElectorate
        {
            get; set;
        }


        public RegionalCouncilDto RegionalCouncil
        {
            get; set;
        }

        public EducationProviderOrganisationTypeDto EducationProviderType
        {
            get; set;
        }
        public RegionDto Region
        {
            get; set;
        }


        public SpecialSchoolingDto SpecialSchooling
        {
            get; set;
        }


        public TeacherEducationDto TeacherEducation
        {
            get; set;
        }

        public TerritorialAuthorityDto TerritorialAuthority
        {
            get; set;
        }


        public UrbanAreaDto UrbanArea
        {
            get; set;
        }


        public WardDto Ward
        {
            get; set;
        }

        // ---------------------


        public virtual ICollection<EducationProviderLocationDto> Locations
        {
            get; set;
        }
        /*{
            get
            {
                return _locations ?? (_locations = new Collection<EducationProviderLocation>());
            }
            //set => _locations = value;
        }
        private ICollection<EducationProviderLocation> _locations;
        */




        // ---------------------

        public virtual ICollection<EducationProviderLevelGenderDto> LevelGender
        {
            get; set;
        }
        /*{
            get
            {
                return _levelGender ?? (_levelGender = new Collection<EducationProviderLevelGender>());
            }
            //set => _levelGender = value;
        }
        private ICollection<EducationProviderLevelGender> _levelGender;
        */



        public virtual ICollection<EducationProviderEnrolmentCountDto> RollCounts
        {
            get; set;
        }
        /*{
            get { return this._rollCount ?? (this._rollCount = new Collection<EducationProviderEnrolmentCount>()); }
            //set => _rollCount = value;
        }
        private ICollection<EducationProviderEnrolmentCount> _rollCount;
        */
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
        public string SourceSystemKey
        {
            get; set;
        }

        public string SourceSystemName
        {
            get; set;
        }
    }
}
