// Extensions are always put in root namespace
// for maximum usability from elsewhere:

namespace App
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    public static class AppDomainExtensions
    {
        public static void InvokeImplementing<T>(this AppDomain appDomain, Action<T> func)
        {
            foreach (var foundType in appDomain.GetInstantiableTypesImplementing(typeof(T)))
            {
                var tmp = (T) Activator.CreateInstance(foundType);

                func(tmp);
            }
        }

        public static IEnumerable<Type> GetInstantiableTypesImplementing(this AppDomain appDomain, Type type)
        {
            var results = new List<Type>();
            var tmp = appDomain.GetAssemblies();
            foreach (var assembly in tmp)
            {
                var r = assembly.GetInstantiableTypesImplementing(type);
                if (r == null)
                {
                    continue;
                }
                results.AddRange(r);
            }
            return results;
        }

        //Expected to be invoked with AppDomain.CurrentDomain
        public static void LoadAllBinDirectoryAssemblies(this AppDomain appDomain)
        {
            var binPath =
                Path.Combine(appDomain.BaseDirectory,
                    "bin"); // note: don't use CurrentEntryAssembly or anything like that.
            if (!Directory.Exists(binPath))
            {
                binPath = appDomain.BaseDirectory;
            }
            var filenames = Directory.GetFiles(binPath, "*.dll", SearchOption.AllDirectories);

            foreach (var fileName in filenames)
            {
                try
                {
                    var loadedAssembly = Assembly.LoadFile(fileName);
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (FileLoadException loadEx)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                } // The Assembly has already been loaded.
#pragma warning disable 168
                catch (BadImageFormatException imgEx)
#pragma warning restore 168
                {
                } // If a BadImageFormatException exception is thrown, the file is not an assembly.
            } // foreach dll
        }
    }
}