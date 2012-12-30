using System.Data;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using RConDevServer.Protocol.Dice.Battlefield3.DataMapping;
using RConDevServer.Protocol.Interface;

namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    public class Battlefield3DataContext : IDataContext
    {
        #region Contstructor

        public Battlefield3DataContext(IServiceLocator serviceLocator)
        {
            this.ServiceLocator = serviceLocator;
            this.Initialize();
        }

        #endregion

        #region Public Properties

        public IServiceLocator ServiceLocator { get; set; }

        public ISessionFactory SessionFactory { get; private set; }

        #endregion

        #region Private Methods

        private void Initialize()
        {
            var connectionString = ServiceLocator.GetService<IDbConnection>().ConnectionString;
            this.SessionFactory = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.ConnectionString(connectionString))
                .Mappings(x => x.FluentMappings
                    .Add<MapMapping>()
                    .Add<GameModeMapping>()
                    .Add<IdTypeMapping>()
                    .Add<CountryMapping>()
                    .Add<PlayerListStoreItemMapping>())
                .BuildSessionFactory();
        }

        #endregion
    }
}
