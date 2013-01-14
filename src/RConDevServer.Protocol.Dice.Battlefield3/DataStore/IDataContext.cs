namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    using Interface;
    using NHibernate;

    public interface IDataContext
    {
        IServiceLocator ServiceLocator { get; set; }

        ISessionFactory SessionFactory { get; }
    }
}