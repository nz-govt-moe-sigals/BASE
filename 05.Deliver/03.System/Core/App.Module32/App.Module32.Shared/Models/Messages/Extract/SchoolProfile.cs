using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Module32.Shared.Models.Messages.Extract.Base;
using Newtonsoft.Json;

namespace App.Module32.Shared.Models.Messages.Extract
{
    public class SchoolProfile : BaseMessage
    {
        [JsonProperty("School_Id")]
        public int SchoolId { get; set; }

        [JsonProperty("Org_Name")]
        public string OrgName { get; set; }
    }
}
