namespace RConDevServer.Util
{
    using System;
    using System.Linq;
    using Ninject;
    using Ninject.Modules;
    using Protocol.Interface;
    using log4net;

    public class NinjectServiceLocator : IServiceLocator
    {
        public static readonly ILog logger = LogManager.GetLogger(typeof (NinjectServiceLocator));

        public NinjectServiceLocator(IKernel kernel)
        {
            this.Kernel = kernel;
        }

        public IKernel Kernel { get; private set; }

        public T GetService<T>()
        {
            return this.Kernel.Get<T>();
        }

        public T GetService<T>(string name)
        {
            try
            {
                return this.Kernel.Get<T>(name);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public bool RegisterService(Type type, object service)
        {
            try
            {
                // only one instance per interface type is possible
                if (!this.Kernel.GetBindings(type).Any())
                {
                    this.Kernel.Bind(type).ToConstant(service);
                }
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("Failed registering service '{0}' ", type), ex);
                return false;
            }
        }

        public bool RegisterNamedService<TInterface, TImplementation>(string name) where TImplementation : TInterface
        {
            try
            {
                this.Kernel.Bind<TInterface>().To<TImplementation>().Named(name);
                return true;
            }
            catch (Exception ex)
            {
                string message = string.Format("Failed registering service '{0}' to '{1}' with name '{2}'",
                                               typeof (TInterface).Name, typeof (TImplementation).Name, name);
                logger.Error(message, ex);
                return false;
            }
        }

        public void Load(INinjectModule module)
        {
            this.Kernel.Load(module);
        }

        public bool UnregisterService(Type type)
        {
            try
            {
                this.Kernel.Unbind(type);
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