using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module80.Shared.Models.Messages.API
{
    public class SurveyLitterItemDto
    {
        public Guid SurveyId { get; set; }

        public string Code { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public decimal Weight { get; set; }

        public int Count { get; set; }
    }
}
