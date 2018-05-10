﻿using System.Collections.Generic;
using System.Web.Http;
using App.Core.Infrastructure.Initialization.OData;

namespace App.Core.Application.Initialization.OData
{


    /// <summary>
    /// Contract for a *Typed* implementation of Model Builder
    /// that will scan for just this Module's 
    /// Model Builder Configuration files.
    /// <para>
    /// Note that Instances will *not* be registered against 
    /// this interface, but will instead by registed against
    /// the *untyped* base contract (IAppCoreOdataModelBuilderBuilderBase)
    /// </para>
    /// </summary>
    public interface IOdataModelBuilder : IOdataModelBuilderStub
    {
        /// <summary>
        /// Returns to the Route Prefix (Module3, ModuleX, etc.)
        /// <para>
        /// Invoked by Shell (should it be Core?)
        ///  when registering Model and building Path.
        /// </para>
        /// </summary>
        /// <returns></returns>
        string GetRoutePrefix();

        IEnumerable<Microsoft.OData.Edm.IEdmModel> GetEdmModels(HttpConfiguration configuration);
    }
}