namespace App.Core.Infrastructure.DependencyResolution
{
    using System;
    using StructureMap;

    // When the App starts up it invokes StructuremapMvc
    // which sets up this class (watch out to make sure that
    // updating the StructureMap package does not overwrite
    // and remove that custom added line in StructuremapMvc).
    public static class StructureMapContainerLocator
    {
        private static Func<IContainer> _func;

        public static IContainer Container => _func?.Invoke();

        public static void Register(Func<IContainer> func)
        {
            _func = func;
        }
    }
}