using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Shared.Models.Messages.Extract
{
    public abstract class BaseReference : BaseMessage
    {
        //[JsonProperty("Code")]
        public string Code { get; set; }

        //[JsonProperty("Description")]
        public string Description { get; set; }

        //[JsonProperty("Comments")]
        public string Comments { get; set; }
    }
}
