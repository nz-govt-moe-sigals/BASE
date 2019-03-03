namespace App.Core.Infrastructure.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Practices.ServiceLocation;
    using StructureMap;

    public class StructureMapServiceLocator : ServiceLocatorImplBase
    {
        private readonly IContainer _container;

        public StructureMapServiceLocator(IContainer container)
        {
            this._container = container;
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            return string.IsNullOrEmpty(key)
                ? this._container.GetInstance(serviceType)
                : this._container.GetInstance(serviceType, key);
        }


        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return this._container.GetAllInstances(serviceType).Cast<object>();
        }
    }
}