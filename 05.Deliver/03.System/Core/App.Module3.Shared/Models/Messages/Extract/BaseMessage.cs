using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Shared.Models.Messages.Extract
{
    public abstract class BaseMessage 
    {
        //[JsonProperty("id")]
        public Guid Id { get; set; }

        //[JsonProperty("ModifiedBy")]
        public string ModifiedBy { get; set; }

        //[JsonProperty("ModifiedDate")]
        public DateTime ModifiedDate { get; set; }

        //[JsonProperty("SourceDataLastModified")]
        public DateTime SourceDataLastModified { get; set; }

        //[JsonProperty("table_name")]
        public string TableName { get; set; }
    }
}
