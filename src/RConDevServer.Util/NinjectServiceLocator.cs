using System;
using System.Linq;
using Ninject;
using RConDevServer.Protocol.Interface;
using log4net;

namespace RConDevServer.Util
{
    public class NinjectServiceLocator : IServiceLocator
    {
        public static readonly ILog logger = LogManager.GetLogger(typeof(NinjectServiceLocator));

        public IKernel Kernel { get; private set; }

        public NinjectServiceLocator(IKernel kernel)
        {
            this.Kernel = kernel;
        }

        public T GetService<T>()
        {
            return Kernel.Get<T>();
        }

        public bool RegisterService(Type type, object service)
        {
            try
            {
                // only one instance per interface type is possible
                if (!this.Kernel.GetBindings(type).Any())
                {
                    Kernel.Bind(type).ToConstant(service);
                }
                return true;
            }
            catch(Exception ex)
            {
                logger.Error(string.Format("Failed registering service '{0}' ", type), ex);
                return false;
            }
        }

        public bool UnregisterService(Type type)
        {
            try
            {
                Kernel.Unbind(type);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("Failed unregistering service '{0}' ", type), ex);
                return false;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
