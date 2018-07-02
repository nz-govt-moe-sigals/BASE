using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Configuration.Implementations.AppHostNames
{
    public class RouteElementCollection : ConfigurationElementCollection
    {
        internal const string PropertyName = "route";

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMapAlternate;
            }
        }
        protected override string ElementName
        {
            get
            {
                return PropertyName;
            }
        }

        protected override bool IsElementName(string elementName)
        {
            return elementName.Equals(PropertyName,
                StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool IsReadOnly()
        {
            return false;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new RouteElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RouteElement)(element)).Name;
        }

        public RouteElement this[int idx]
        {
            get { return (RouteElement)BaseGet(idx); }
        }
    }
}
