using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Module32.Shared.Models.Messages.Extract.Base;
using Newtonsoft.Json;

namespace App.Module32.Shared.Models.Messages.Extract
{
    public class StudentProfile : BaseMessage
    {
        [JsonProperty("NSN")]
        public string NSN { get; set; }

        [JsonProperty("School_Id")]
        public int SchoolId { get; set; }

        [JsonProperty("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("Gender")]
        public string Gender { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("MiddleName")]
        public string MiddleName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

 
    }
}
