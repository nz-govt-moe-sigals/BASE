using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace App.Module32.Shared.Models.Messages.Extract.Base
{
    public abstract class BaseMessage 
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("ModifiedBy")]
        public string ModifiedBy { get; set; }

      

        [JsonProperty("SourceDataLastModified")]
        public DateTime SourceDataLastModified { get; set; }

        [JsonProperty("Table_Name")]
        public string TableName { get; set; }
    }
}
