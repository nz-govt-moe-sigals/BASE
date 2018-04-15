using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Models.Contracts
{
    using Newtonsoft.Json;

    public class IHasDocumentId : IHasId<string>
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}
