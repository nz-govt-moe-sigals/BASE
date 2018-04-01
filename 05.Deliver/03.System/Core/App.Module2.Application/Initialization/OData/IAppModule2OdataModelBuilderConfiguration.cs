﻿namespace App.Module2.Application.Initialization.OData
{
    using System.Web.OData.Builder;
    using App.Core.Infrastructure.Initialization.OData;

    /// <summary>
    /// A Module specific implementation of
    /// <see cref="IOdataModelBuilderConfigurationBase"/>
    /// allowing for defining odata apis 'clumped by module' (ie distinct metadatas...)
    /// </summary>
    public interface IAppModule2OdataModelBuilderConfiguration : IOdataModelBuilderConfigurationBase
    {
        void Define(ODataModelBuilder builder);
    }


}