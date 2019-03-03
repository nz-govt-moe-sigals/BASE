using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services
{
    /// <summary>
    /// Contract for an injectable app specific service to 
    /// solve dependencies, while 
    /// not causing downstream assemblies to have to take a 
    /// reference to the Microsoft Common ServiceLocator
    /// or even the singleton AppDependencyLocator.
    /// </summary>
    public interface IDependencyResolutionService : IHasAppCoreService
    {
        T GetInstance<T>();
        T GetInstance<T>(string key);
        object GetInstance(Type type);
        object GetInstance(Type type, string key);

        IEnumerable<T> GetAllInstances<T>();
        IEnumerable<object> GetAllInstances(Type type);
    }
}
