// Extensions are always put in root namespace
// for maximum usability from elsewhere:

namespace App
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class AssemblyExtensions
    {
        //[System.Diagnostics.DebuggerHidden]
        public static IEnumerable<Type> GetInstantiableTypesImplementing(this Assembly assembly, Type type)
        {
            // Return only types that are subsets of the given type (or are same)
            // that are instantiable, and not generic.

            //An Alternate way of investigating whether it is an interface or not
            //is typeof(HasDo).GetInterfaces().Any(x=>x == typeof(IHasDo)).Dump("Implements Interface");
            try
            {
                return assembly.GetTypes().Where(x =>
                    type.IsAssignableFrom(x)
                    &&
                    !x.IsAbstract
                    &&
                    !x.IsInterface
                    &&
                    !x.IsGenericTypeDefinition
                );
            }
            catch (ReflectionTypeLoadException)
            {
                //No biggie
            }
            return null;
        }
    }
}