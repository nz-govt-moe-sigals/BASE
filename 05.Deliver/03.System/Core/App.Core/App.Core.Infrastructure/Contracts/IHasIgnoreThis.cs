using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Contracts
{
    /// <summary>
    /// Contract that can be attached to classes that need to be ignored (eg: by Reflection)
    /// <para>
    /// Have used to ignore some Entity Framework Schema definitions, etc.
    /// </para>
    /// </summary>
    public interface IHasIgnoreThis 
    {
    }
}
