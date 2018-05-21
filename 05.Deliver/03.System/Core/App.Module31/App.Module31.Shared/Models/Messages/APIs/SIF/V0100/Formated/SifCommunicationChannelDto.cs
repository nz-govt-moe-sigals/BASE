using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module31.Shared.Models.Messages.APIs.SIF.V0100.Formated
{
    public class SifCommunicationChannelDto
    {
        public string Notes { get; set; }

        public uint? Preference { get; set; }

        public string Usage { get; set; }

        public string Type { get; set; }
        
        public string Value { get; set; }
    }
}





