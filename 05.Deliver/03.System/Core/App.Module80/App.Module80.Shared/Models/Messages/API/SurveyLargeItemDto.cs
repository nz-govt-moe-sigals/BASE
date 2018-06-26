using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Module80.Shared.Models.Entities.Enums;

namespace App.Module80.Shared.Models.Messages.API
{
    public class SurveyLargeItemDto
    {
        public Guid SurveyId { get; set; }

        public string Code { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public int Count { get; set; }

        public decimal? Longitude { get; set; }

        public decimal? Latitude { get; set; }

        public LargeItemStatus Status { get; set; }

        public string DetailedDescription { get; set; }
    }
}
