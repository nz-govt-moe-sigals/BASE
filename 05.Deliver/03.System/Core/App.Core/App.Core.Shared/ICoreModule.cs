using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core
{

    /// <summary>
    /// Unique base identifier used by this Module's
    /// common named
    /// <see cref="IHasModuleSpecificIdentifier"/>.
    /// <para>
    /// It's very important that once you create a new Module
    /// that you ensure this contract is renamed, before doing 
    /// anything. 
    /// </para>
    /// </summary>
    public interface ICoreModule
    {
    }
}
