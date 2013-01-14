namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    using System.Collections.Generic;
    using Data;
    using Interface;
    using NHibernate;
    using NHibernate.Criterion;

    public class PlayerListStoreRepository : IPlayerListStoreRepository
    {
        public PlayerListStoreRepository(IServiceLocator serviceLocator)
        {
            this.ServiceLocator = serviceLocator;
        }

        public IServiceLocator ServiceLocator { get; private set; }

        public IEnumerable<PlayerListStoreItem> GetAll()
        {
            var dataContext = this.ServiceLocator.GetService<IDataContext>();
            using (ISession session = dataContext.SessionFactory.OpenSession())
            {
                return session.CreateCriteria<PlayerListStoreItem>().List<PlayerListStoreItem>();
            }
        }

        public void Save(PlayerListStoreItem item)
        {
            var dataContext = this.ServiceLocator.GetService<IDataContext>();
            using (ISession session = dataContext.SessionFactory.OpenSession())
            {
                session.SaveOrUpdate(item);
                session.Flush();
            }
        }

        public PlayerListStoreItem Get(long playerListStoreId)
        {
            var dataContext = this.ServiceLocator.GetService<IDataContext>();
            using (ISession session = dataContext.SessionFactory.OpenSession())
            {
                return session.CreateCriteria<PlayerListStoreItem>()
                              .Add(Restrictions.Eq("Id", playerListStoreId))
                              .SetMaxResults(1)
                              .UniqueResult<PlayerListStoreItem>();
            }
        }
    }
}