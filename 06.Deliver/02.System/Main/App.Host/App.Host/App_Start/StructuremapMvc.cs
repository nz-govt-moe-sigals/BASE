// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StructuremapMvc.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using App.Core.Application.App_Start;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Host.DependencyResolution;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(StructuremapMvc), "Start")]
[assembly: ApplicationShutdownMethod(typeof(StructuremapMvc), "End")]

namespace App.Core.Application.App_Start {
	using System.Web.Mvc;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

	using App.Core.Application.DependencyResolution;

    using StructureMap;

    /// <summary>
    /// A <see cref="Startup"/> invoked class (ie, before DI has been set up) to configure 
    /// StructureMap so that DI can be used as soon as possible 
    /// in the system's lifespan, starting with 
    /// <see cref="StartupExtended"/>.
    /// </summary>
    public static class StructuremapMvc {

        public static StructureMapDependencyScope StructureMapDependencyScope { get; set; }

        /// <summary>
        /// <para>
        /// Invoked from <see cref="StartupExtended.Configure"/>.
        /// </para>
        /// </summary>
        public static void Start()
        {
            StructureMapDependencyScope = StructureMapDependencyScopeFactory.ConfigureContainer();

            // --------------------------------------------------
            //Register container so that App.Core.Infrastructure.ServiceLocatorInitiator
            //Can get back to it:
            StructureMapContainerLocator.Register(
                () => StructureMapDependencyScope.Container);
            // --------------------------------------------------

            DependencyResolver.SetResolver(StructureMapDependencyScope);
            DynamicModuleUtility.RegisterModule(typeof(StructureMapScopeModule));

            // Find out what is available in the container:
            //container.Model.For<IFantasySeries>()
            //    .Instances.Select(x => x.ReturnedType)
            //    .OrderBy(x => x.Name)
            //    .ShouldHaveTheSameElementsAs(typeof(BlackCompany), typeof(GameOfThrones), typeof(WheelOfTime));
        }


        public static void End()
        {
            StructureMapDependencyScope.Dispose();
        }

    }


}