using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using RConDevServer.Protocol.Interface;

namespace RConDevServer.Core
{
    using log4net;

    public class ProtocolLoader 
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ProtocolLoader));

        public IList<IRconProtocol> LoadProtocols(string directory, IServiceLocator serviceLocator)
        {
            var directoryInfo = new DirectoryInfo(directory);
            IList<IRconProtocol> protocols = new List<IRconProtocol>();
            if (directoryInfo.Exists)
            {
                var assemblies = directoryInfo.GetFiles("*.dll");
                foreach (var assemblyFile in assemblies)
                {
                    try
                    {
                        logger.DebugFormat("Loading Assembly: {0}", assemblyFile.Name);
                        var assembly = Assembly.LoadFrom(assemblyFile.FullName);

                        var protocolImplList =
                            assembly.GetTypes().Where(x => typeof (IRconProtocol).IsAssignableFrom(x)).ToList();
                        if (protocolImplList.Count == 1)
                        {
                            var protocolType = protocolImplList[0];
                            var instance = Activator.CreateInstance(protocolType) as IRconProtocol;
                            if (instance != null)
                            {
                                instance.ServiceLocator = serviceLocator;
                                protocols.Add(instance);
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        logger.Error(string.Format("Failed to load assembly '{0}'", assemblyFile.Name), ex);
                    }
                }
            }
            return protocols;
        }
    }
}
