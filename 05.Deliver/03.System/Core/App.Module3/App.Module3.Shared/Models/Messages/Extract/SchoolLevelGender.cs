using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Shared.Models.Messages.Extract
{
    /// <summary>
    /// Table Name : Schools_Directory_API_School_Level_Gender
    /// </summary>
    public class SchoolLevelGender : BaseMessage
    {
        [JsonProperty("Level_Gender_Id")]
        public int LevelGenderId { get; set; }

        [JsonProperty("School_Id")]
        public int SchoolId { get; set; }

        [JsonProperty("YearValue_ID")]
        public string YearValueId { get; set; }

        [JsonProperty("GenderValue_ID")]
        public string GenderValueId { get; set; }
    }
}
