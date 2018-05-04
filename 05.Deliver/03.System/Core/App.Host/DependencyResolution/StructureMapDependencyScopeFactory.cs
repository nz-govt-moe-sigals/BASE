﻿namespace App.Core.Application.DependencyResolution
{
    using App.Core.Infrastructure.DependencyResolution;

    public class StructureMapDependencyScopeFactory
    {
        public static StructureMapDependencyScope ConfigureContainer()
        {
            // Use the Singleton to make a container
            // that has its Scanining defined:
            var container = IoC.Initialize();
            var result = new StructureMapDependencyScope(container);
            return result;
        }
    }
}