using NHibernate;
using RConDevServer.Protocol.Interface;

namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    public interface IDataContext
    {
        IServiceLocator ServiceLocator { get; set; }
        
        ISessionFactory SessionFactory { get; }
    }
}