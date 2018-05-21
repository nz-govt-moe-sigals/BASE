using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module11.Shared.Constants.Sif
{
    public enum SifEmailTypeType
    {
        [Description("01")]
        Primary,
        [Description("02")]
        Alernate1,
        [Description("03")]
        Alternate2,
        [Description("04")]
        Alternate3,
        [Description("05")]
        Alternate4,
        [Description("06")]
        Work,
        [Description("07")]
        Personal

    }
}
