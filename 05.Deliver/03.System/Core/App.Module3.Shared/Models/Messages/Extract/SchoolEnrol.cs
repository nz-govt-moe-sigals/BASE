using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Shared.Models.Messages.Extract
{
    /// <summary>
    /// Table Name : Schools_Directory_API_School_Enrol
    /// </summary>
    public class SchoolEnrol : BaseMessage
    {
        //[JsonProperty("Enrol_Id")]
        public int EnrolId { get; set; }

        //[JsonProperty("School_Id")]
        public int SchoolId { get; set; }

        //[JsonProperty("Effective_Date")]
        public DateTime? EffectiveDate { get; set; }

        //[JsonProperty("International")]
        public int International { get; set; }

        //[JsonProperty("European")]
        public int European { get; set; }

        //[JsonProperty("Maori")]
        public int Maori { get; set; }

        //[JsonProperty("Pasifika")]
        public int Pasifika { get; set; }

        //[JsonProperty("Asian")]
        public int Asian { get; set; }

        //[JsonProperty("MELAA")]
        public int Melaa { get; set; }

        //[JsonProperty("Other")]
        public int Other { get; set; }
    }
}
