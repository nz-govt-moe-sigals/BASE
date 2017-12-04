namespace App
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Practices.ServiceLocation;

    public class AppDependencyLocator
    {
        static AppDependencyLocator()
        {
            Current = new AppDependencyLocator();
        }

        //Wrap the Common Service Locator provided
        // by the 3rd party (in this case MS) so 
        // that other assemblies have as few direct
        // dependencies as possible.
        public static AppDependencyLocator Current { get; }

        public object GetService(Type serviceType)
        {
            return ServiceLocator.Current.GetService(serviceType);
        }

        public object GetInstance(Type serviceType)
        {
            return ServiceLocator.Current.GetInstance(serviceType);
        }

        public object GetInstance(Type serviceType, string key)
        {
            return ServiceLocator.Current.GetInstance(serviceType, key);
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return ServiceLocator.Current.GetAllInstances(serviceType);
        }

        public TService GetInstance<TService>()
        {
            return ServiceLocator.Current.GetInstance<TService>();
        }

        public TService GetInstance<TService>(string key)
        {
            return ServiceLocator.Current.GetInstance<TService>(key);
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return ServiceLocator.Current.GetAllInstances<TService>();
        }
    }
}