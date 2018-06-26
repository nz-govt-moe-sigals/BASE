using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module80.Shared.Models.Messages.API
{
    public class SurveyDto
    {
        public Guid? Id { get; set; }


        private DateTime _creatdDateTime;

        public string Name { get; set; }

        public SurveyLocationDto SurveyLocation { get; set; }

        public OrganisationDto Organisation { get; set; }

        public int NumberOfPersonsInvolved { get; set; }

        public DateTime CreatedDate
        {
            get { return _creatdDateTime.Date;}
            set { _creatdDateTime = value; }
        }

        public DateTime? StartTime { get; set; }

        public decimal? StartLongitude { get; set; }

        public decimal? StartLatitude { get; set; }


        public DateTime? EndTime { get; set; }

        public decimal? EndLongitude { get; set; }

        public decimal? EndLatitude { get; set; }


        public ICollection<SurveyLargeItemDto> LargeItems { get; set; }

        public ICollection<SurveyLitterItemDto> LitterItems { get; set; }
    }
}
