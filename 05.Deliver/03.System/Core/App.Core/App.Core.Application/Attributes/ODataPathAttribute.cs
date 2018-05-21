using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Application.Attributes
{
    using App.Core.Shared.Attributes;

    public class ODataPathAttribute : KeyAttribute
    {
        public ODataPathAttribute(string key) : base(key)
        {
        }
    }
}
