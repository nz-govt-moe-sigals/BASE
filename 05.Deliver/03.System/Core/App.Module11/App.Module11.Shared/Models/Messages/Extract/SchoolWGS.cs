using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module11.Shared.Models.Messages.Extract
{
    /// <summary>
    /// Table Name : Schools_Directory_API_School_WGS
    /// </summary>
    public class SchoolWGS : BaseMessage
    {
        [JsonProperty("WGS_Id")]
        public int WgsId { get; set; }

        [JsonProperty("Institution_Number")]
        public int InstitutionNumber { get; set; }

        [JsonProperty("WGS_X")]
        public float? WgsX { get; set; }

        [JsonProperty("WGS_Y")]
        public float? WgsY { get; set; }
    }
}
