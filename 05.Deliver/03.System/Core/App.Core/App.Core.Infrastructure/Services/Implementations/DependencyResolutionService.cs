using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Core.Infrastructure.Services.Implementations;
using StructureMap;
using System;
using System.Collections.Generic;

namespace App.Core.Infrastructure.Services
{
    public class DependencyResolutionService: AppCoreServiceBase, IDependencyResolutionService
    {
        public T GetInstance<T>()
        {
            return AppDependencyLocator.Current.GetInstance<T>();
        }
        public T GetInstance<T>(string key)
        {
            return AppDependencyLocator.Current.GetInstance<T>(key);
        }

        public object GetInstance(Type type)
        {
            return AppDependencyLocator.Current.GetInstance(type);
        }

        public object GetInstance(Type type, string key)
        {
            return AppDependencyLocator.Current.GetInstance(type, key);
        }


        public IEnumerable<T> GetAllInstances<T>()
        {
            return AppDependencyLocator.Current.GetAllInstances<T>();
        }
        public IEnumerable<object> GetAllInstances(Type type)
        {
            return AppDependencyLocator.Current.GetAllInstances(type);
        }


        private IContainer GetContainer()
        {
            IContainer r = StructureMapContainerLocator.Container;
            return r;
        }
        //public void Register<T>(string key)
        //{

        //    new CreatePluginFamilyExpression<IAppCoreCacheItem>(this,
        //            new StructureMap.Pipeline.SingletonLifecycle())
        //            .Use(y => (IAppCoreCacheItem)AppDependencyLocator.Current.GetInstance(t)).Named(name);




        //}
    }
}
