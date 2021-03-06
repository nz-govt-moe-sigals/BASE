﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module01.Infrastructure.Services.Configuration
{
    using App.Core.Infrastructure.Services.Configuration;

    /// <summary>
    /// Not sure if there is any benefit being able to reflect for Configuration
    /// objects per Module, but just in case.
    /// 
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.Configuration.IServiceConfigurationObject" />
    public interface IModuleServiceConfigurationObject : IServiceConfigurationObject, IHasModuleSpecificIdentifier
    {

    }
}
