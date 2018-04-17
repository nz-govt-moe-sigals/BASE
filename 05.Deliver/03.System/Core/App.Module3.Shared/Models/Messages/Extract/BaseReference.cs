using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Models.Messages.EDK
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
