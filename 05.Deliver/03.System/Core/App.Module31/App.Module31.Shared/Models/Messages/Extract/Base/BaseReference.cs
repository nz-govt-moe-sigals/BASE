using Newtonsoft.Json;

namespace App.Module31.Shared.Models.Messages.Extract.Base
{
    public abstract class BaseReference : BaseMessage
    {
        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Comments")]
        public string Comments { get; set; }
    }
}





