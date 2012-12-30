using System;

namespace RConDevServer.Protocol.Interface
{
    public interface IServiceLocator : ICloneable
    {
        T GetService<T>();

        bool RegisterService(Type type, object service);

        bool UnregisterService(Type type);
    }
}
