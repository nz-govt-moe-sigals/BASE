using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module11.Infrastructure.Constants.Module
{
    public static class Names
    {
        /// <summary>
        /// The programmatic name for the Module.
        /// <para>
        /// For now, only one db per Module, but could be more at some point:        
        /// </para>
        /// <para>
        /// Note: Basis of the DbContext's Schema unless specifically set otherwise. 
        /// So don't change it without appropriate forethought.
        /// </para>
        /// <para>
        /// Note: Also the basis for the root of the OData paths unless specifically set otherwise. 
        /// So don't change it without appropriate forethought.
        /// Note that in this case, it is overridden.
        /// </para>
        /// </summary>
        public const string ModuleKey = "Module11";
    }
}
