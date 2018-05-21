using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module11.Shared.Models.Messages.APIs.SIF.V0100.Formated
{
    public class SifEnactedPolicyDto
    {
        public DateTime? EffectiveTo { get; set; }

        public DateTime? EffectiveFrom { get; set; }

        public string Policy { get; set; }
    }
}
