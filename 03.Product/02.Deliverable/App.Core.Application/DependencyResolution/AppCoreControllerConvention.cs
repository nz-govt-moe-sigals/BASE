namespace App.Core.Application.DependencyResolution
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Mvc;
    using App.Core.Infrastructure.DependencyResolution;
    using StructureMap;
    using StructureMap.Graph.Scanning;
    using StructureMap.Pipeline;
    using StructureMap.TypeRules;

    public class AppCoreControllerConvention : ICustomRegistrationConvention
    {
        public void ScanTypes(TypeSet types, Registry registry)
        {
            var found = types.FindTypes(
                    TypeClassification.Concretes | TypeClassification.Closed)
                .Where(x => x.CanBeCastTo<Controller>() | x.CanBeCastTo<ApiController>())
                .ToArray();

            foreach (var t in found)
            {
                {
                    registry.For(t).LifecycleIs(new UniquePerRequestLifecycle());
                }
                ;
            }
        }
    }
}