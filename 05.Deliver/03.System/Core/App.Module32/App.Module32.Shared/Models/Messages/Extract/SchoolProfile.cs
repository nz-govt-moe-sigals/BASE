using System;
using App.Module32.Shared.Models.Messages.Extract.Base;
using Newtonsoft.Json;

namespace App.Module32.Shared.Models.Messages.Extract
{
    public class SchoolProfile : BaseMessage, IExtractMessage
    {
        [JsonProperty("School_Id")]
        public int SchoolId { get; set; }

        [JsonProperty("Org_Name")]
        public string OrgName { get; set; }

        [JsonProperty("ModifiedDate")]
        public DateTime ModifiedDate { get; set; }

    }
}
