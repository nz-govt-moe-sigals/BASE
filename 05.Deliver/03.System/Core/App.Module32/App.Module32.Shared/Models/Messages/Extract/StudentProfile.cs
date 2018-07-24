using System;
using App.Module32.Shared.Models.Messages.Extract.Base;
using Newtonsoft.Json;

namespace App.Module32.Shared.Models.Messages.Extract
{
    public class StudentProfile : BaseMessage, IExtractMessage
    {
        [JsonProperty("NSN")]
        public string NSN { get; set; }

        [JsonProperty("SchoolID")]
        public int SchoolId { get; set; }

        [JsonProperty("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("MiddleName")]
        public string MiddleName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("ModifiedDateTime")]
        public DateTime ModifiedDate { get; set; }


    }
}
