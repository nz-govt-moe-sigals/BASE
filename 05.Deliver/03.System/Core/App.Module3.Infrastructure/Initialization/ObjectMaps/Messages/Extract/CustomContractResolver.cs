using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Messages.Extract
{
    public abstract class CustomContractResolver<T> : DefaultContractResolver
    {
        protected Dictionary<string, string> PropertyMappings { get; set; }

        protected void AddMap<U>(Expression<Func<T, U>> expression)
        {
            if (PropertyMappings == null)
            {
                PropertyMappings = new Dictionary<string, string>();
            }
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null) return;
            PropertyMappings.Add(memberExpression.Member.Name, memberExpression.Member.Name);
        }

        protected void AddMap<U>(Expression<Func<T, U>> expression, string jsonPropertyName)
        {
            if (PropertyMappings == null)
            {
                PropertyMappings = new Dictionary<string, string>();
            }
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null) return;
            PropertyMappings.Add(memberExpression.Member.Name, jsonPropertyName);
        }

        protected override string ResolvePropertyName(string propertyName)
        {
            string resolvedName = null;
            var resolved = PropertyMappings.TryGetValue(propertyName, out resolvedName);
            return (resolved) ? resolvedName : base.ResolvePropertyName(propertyName);
        }
    }
}
