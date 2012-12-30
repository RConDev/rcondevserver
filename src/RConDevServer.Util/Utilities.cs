using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RConDevServer.Util
{
    /// <summary>
    /// Different utilities
    /// </summary>
    public class Utilities
    {
        /// <summary>
        /// Loads all classes/interfaces of a specific type from a diretory
        /// </summary>
        /// <typeparam name="T">The class/interface type to load</typeparam>
        /// <param name="directoryPath">The diretory path to load from</param>
        /// <param name="directoryInfo">The diretory to load from</param>
        /// <param name="recursive">Load from all sub folders</param>
        /// <returns>Instances of the class/interface</returns>
        public static IList<T> LoadClassesFromDirectory<T>(string directoryPath = "", DirectoryInfo directoryInfo = null,
                                                           bool recursive = true) where T : class
        {
            var directory = directoryInfo ?? new DirectoryInfo(directoryPath);
            var search = SearchOption.TopDirectoryOnly;
            if (recursive)
                search = SearchOption.AllDirectories;

            IList<T> instances = new List<T>();
            if (directory.Exists)
            {
                var assemblies = directory.GetFiles("*.dll", search);
                foreach (var assemblyFile in assemblies)
                {
                    var assembly = Assembly.LoadFrom(assemblyFile.FullName);
                    var protocolImplList =
                        assembly.GetTypes().Where(x => typeof (T).IsAssignableFrom(x)).Where(x => x.IsInterface == false)
                            .Where(x => x.IsAbstract == false).ToList();
                    foreach (var instance in protocolImplList.Select(type => Activator.CreateInstance(type) as T))
                    {
                        instances.Add(instance);
                    }
                }
            }
            return instances;
        }
    }
}