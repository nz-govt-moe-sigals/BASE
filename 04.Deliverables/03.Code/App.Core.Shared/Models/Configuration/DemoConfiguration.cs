using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Models.Configuration
{
    using App.Core.Shared.Attributes;

    public class DemoConfiguration
    {
        [Alias("App:Core:DemoMode")]
        public bool DemoMode
        {
            get; set;
        }
    }
}
