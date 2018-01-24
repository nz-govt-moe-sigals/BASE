namespace App.Core.Infrastructure.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Practices.ServiceLocation;
    using StructureMap;

    public class StructureMapServiceLocator : ServiceLocatorImplBase
    {
        private readonly IContainer container;

        public StructureMapServiceLocator(IContainer container)
        {
            this.container = container;
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            return string.IsNullOrEmpty(key)
                ? this.container.GetInstance(serviceType)
                : this.container.GetInstance(serviceType, key);
        }


        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return this.container.GetAllInstances(serviceType).Cast<object>();
        }
    }
}