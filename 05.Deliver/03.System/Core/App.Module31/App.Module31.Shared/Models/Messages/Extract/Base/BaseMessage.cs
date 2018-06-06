using System;
using Newtonsoft.Json;

namespace App.Module31.Shared.Models.Messages.Extract.Base
{
    public abstract class BaseMessage 
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("ModifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonProperty("ModifiedDate")]
        public DateTime ModifiedDate { get; set; }

        [JsonProperty("SourceDataLastModified")]
        public DateTime SourceDataLastModified { get; set; }

        [JsonProperty("Table_Name")]
        public string TableName { get; set; }
    }
}





