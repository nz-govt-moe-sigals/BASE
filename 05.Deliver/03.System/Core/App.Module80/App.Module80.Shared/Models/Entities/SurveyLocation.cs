using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Shared.Models.Entities;

namespace App.Module80.Shared.Models.Entities
{
    public class SurveyLocation : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase
    {
        public string SurveyLocationId { get; set; }

        public string Name { get; set; }

        public string BackOfBeach { get; set; }

        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public string SubstratumType { get; set; }

        public string SubstrateUniformity { get; set; }

        public Guid RegionFK { get; set; }

        public Region Region { get; set; }

        public decimal TidalDistance { get; set; }

        public decimal TidalRange { get; set; }

        public string NearestTown { get; set; }

        public string NearestTownDirection { get; set; }

        public decimal? NearestTownDistance { get; set; }

        public string NearestRiverName { get; set; }

        public string NearestRiverDirection { get; set; }

        public decimal? NearestRiverDistance { get; set; }

        public string RiverInputName { get; set; }

        public bool? PipesOrDrainsInput { get; set; }

        public bool Access { get; set; }

        public ICollection<Survey> Surveys { get; set; }

    }
}
