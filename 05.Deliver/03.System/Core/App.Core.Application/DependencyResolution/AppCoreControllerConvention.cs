namespace App.Core.Application.DependencyResolution
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Mvc;
    using App.Core.Application.DependencyResolution.Interceptors;
    using App.Core.Infrastructure.Contracts;
    using App.Core.Infrastructure.DependencyResolution;
    using StructureMap;
    using StructureMap.Building.Interception;
    using StructureMap.DynamicInterception;
    using StructureMap.Graph.Scanning;
    using StructureMap.Pipeline;
    using StructureMap.TypeRules;

    public class AppCoreControllerConvention : ICustomRegistrationConvention
    {
        public void ScanTypes(TypeSet types, Registry registry)
        {
            //// https://stackoverflow.com/questions/49702579/structuremap-interception-of-controllers

            //// Attach a policy to intercept all Controllers before attaching Controllers...but it raises error.
            //// "Decorator Interceptor failed during object construction. Specified type is not an interface,Parameter name: interfaceToProxy"
            //registry.Policies.Interceptors(
            //    new DynamicProxyInterceptorPolicy(
            //        x => (x.IsConcrete() | !x.IsOpenGeneric()) & (x.CanBeCastTo<Controller>() | x.CanBeCastTo<ApiController>()),
            //        new IInterceptionBehavior[]
            //        {
            //            new AuthorisationInterceptor(),
            //            //new AuditingInterceptor()
            //        }
            //    ));

            // Now find all Controllers/ApiControllers:
            var foundControllers = types.FindTypes(
                                TypeClassification.Concretes | TypeClassification.Closed)
                            .Where(x => x.CanBeCastTo<Controller>() | x.CanBeCastTo<ApiController>())
                            .ToArray();

            // to register them with StructureMap as themselves (ie, no 'Use' statement):
            foreach (var serviceType in foundControllers)
            {
                registry.For(serviceType).LifecycleIs(new UniquePerRequestLifecycle());

                // Although when I tried use/fore, it also raised {"Specified type is not an interface\r\nParameter name: interfaceToProxy"}
                // AttachBehaviour(registry, serviceType);
            }

            //registry.For<IController>().InterceptWith(new DynamicProxyInterceptor<IController>(new IInterceptionBehavior[]{new AuthorisationInterceptor()}));

        }


        //private static void AttachBehaviour(Registry registry, Type serviceType)
        //{
        //    var dynamicProxyInterceptorType = typeof(StructureMap.DynamicInterception.DynamicProxyInterceptor<>);
        //    var genericDynamicProxyInterceptorType = dynamicProxyInterceptorType.MakeGenericType(new[] { serviceType });

        //    var interceptorBehaviors = new StructureMap.DynamicInterception.IInterceptionBehavior[]
        //    {
        //        new AuthorisationInterceptor(),
        //        new AuditingInterceptor()
        //    };
        //    var args = new[] { interceptorBehaviors };

        //    // Create
        //    IInterceptor interceptor =
        //        (StructureMap.Building.Interception.IInterceptor)Activator.CreateInstance(
        //            genericDynamicProxyInterceptorType,
        //            (BindingFlags)0,
        //            null,
        //            args,
        //            null);

        //    // Attach interceptors to Service:
        //    registry.For(serviceType).Use(serviceType).InterceptWith(interceptor);
        //}
    }
}