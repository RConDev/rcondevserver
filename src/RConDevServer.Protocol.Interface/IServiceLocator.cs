using System;

namespace RConDevServer.Protocol.Interface
{
    public interface IServiceLocator : ICloneable
    {
        T GetService<T>();

        T GetService<T>(string name);

        bool RegisterService(Type type, object service);

        bool UnregisterService(Type type);

        bool RegisterNamedService<TInterface, TImplementation>(string name) where TImplementation : TInterface;
    }
}
