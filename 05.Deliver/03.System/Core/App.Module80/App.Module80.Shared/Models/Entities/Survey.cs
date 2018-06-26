using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Shared.Models.Entities;

namespace App.Module80.Shared.Models.Entities
{
    public class Survey : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase
    {
        public Survey()
        {
            
        }


        public string Name { get; set; }

        public Guid BeachFK { get; set; }

        public SurveyLocation SurveyLocation { get; set; }

        public Guid OrganisationFK { get; set; }

        public Organisation Organisation { get; set; }


        public int NumberOfPersonsInvolved { get; set; }


        public DateTime? StartTime { get; set; }

        public decimal? StartLongitude { get; set; }

        public decimal? StartLatitude { get; set; }


        public DateTime? EndTime { get; set; }

        public decimal? EndLongitude { get; set; }

        public decimal? EndLatitude { get; set; }


        public ICollection<SurveyLargeItem> LargeItems { get; set; }

        public ICollection<SurveyLitterItem> LitterItems { get; set; }



    }
}
