using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module01
{
    /// <summary>
    /// <para>
    /// It's really important that this commonly named 
    /// contract -- from which many other contracts and instances
    /// in this module, inherits from -- is tied
    /// to a uniquely named contract. This is so that reflection
    /// can distinguish between different modules, a little bit better
    /// than just with namespaces (which does the same thing, but...easy to miss...)
    /// </para>
    /// </summary>
    public interface IHasModuleSpecificIdentifier : IModule01
    {
    }
}
