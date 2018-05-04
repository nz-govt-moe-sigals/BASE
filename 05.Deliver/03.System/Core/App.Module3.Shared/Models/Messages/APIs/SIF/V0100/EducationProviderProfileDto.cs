using System;

namespace App.Module3.Shared.Models.Messages.APIs.SIF.V0100
{
    using System.Collections.Generic;
    using App.Core.Shared.Factories;
    using App.Core.Shared.Models;
    using App.Module3.Shared.Models.Entities;
    using App.Module3.Shared.Models.Messages.APIs.V0100;

    public class EducationProviderProfileDto : IHasGuidId
    {
        
        public Guid Id { get; set; }

        
        public Guid? ClassificationFK
        {
            get; set;
        }
        public EducationProviderClassificationTypeDto Classification
        {
            get; set;
        }


        public Guid StatusFK
        {
            get; set;
        }
        public EducationProviderStatusDto Status
        {
            get; set;
        }


        public Guid? SchoolingGenderFK
        {
            get; set;
        }
        public EducationProviderSchoolingGenderDto SchoolingGender
        {
            get; set;
        }

        public Guid? LocalOfficeFK
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

        public Guid? CoLFK
        {
            get; set;
        }
        public CoLDto CoL
        {
            get; set;
        }

        public Guid AuthorityTypeFK
        {
            get; set;
        }
        public AuthorityTypeDto AuthorityType
        {
            get; set;
        }



        public Guid? AreaUnitFK
        {
            get; set;
        }
        public AreaUnitDto AreaUnit
        {
            get; set;
        }


        public Guid? CommunityBoardFK
        {
            get; set;
        }
        public CommunityBoardDto CommunityBoard
        {
            get; set;
        }


        public Guid? GeneralElectorateFK
        {
            get; set;
        }
        public GeneralElectorateDto GeneralElectorate
        {
            get; set;
        }


        public Guid? MaoriElectorateFK
        {
            get; set;
        }
        public MaoriElectorateDto MaoriElectorate
        {
            get; set;
        }


        public Guid? RegionalCouncilFK
        {
            get; set;
        }

        public RegionalCouncilDto RegionalCouncil
        {
            get; set;
        }

        public Guid EducationProviderTypeFK
        {
            get; set;
        }

        public EducationProviderOrganisationTypeDto EducationProviderType
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


        public Guid? SpecialSchoolingFK
        {
            get; set;
        }

        public SpecialSchoolingDto SpecialSchooling
        {
            get; set;
        }



        public Guid? TeacherEducationFK
        {
            get; set;
        }

        public TeacherEducationDto TeacherEducation
        {
            get; set;
        }

        public Guid? TerritorialAuthorityFK
        {
            get; set;
        }
        public TerritorialAuthorityDto TerritorialAuthority
        {
            get; set;
        }


        public Guid? UrbanAreaFK
        {
            get; set;
        }
        public UrbanAreaDto UrbanArea
        {
            get; set;
        }


        public Guid? WardFK
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
