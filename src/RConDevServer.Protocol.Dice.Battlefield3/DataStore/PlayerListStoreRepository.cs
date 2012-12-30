using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    using Data;
    using Interface;
    using NHibernate.Criterion;

    public class PlayerListStoreRepository : IPlayerListStoreRepository
    {
        public IServiceLocator ServiceLocator { get; private set; }

        public PlayerListStoreRepository(IServiceLocator serviceLocator)
        {
            this.ServiceLocator = serviceLocator;
        }

        public IEnumerable<PlayerListStoreItem> GetAll()
        {
            var dataContext = ServiceLocator.GetService<IDataContext>();
            using (var session = dataContext.SessionFactory.OpenSession())
            {
                return session.CreateCriteria<PlayerListStoreItem>().List<PlayerListStoreItem>();
            }
        } 

        public void Save(PlayerListStoreItem item)
        {
            var dataContext = ServiceLocator.GetService<IDataContext>();
            using (var session = dataContext.SessionFactory.OpenSession())
            {
                session.SaveOrUpdate(item);
                session.Flush();
            }
        }

        public PlayerListStoreItem Get (long playerListStoreId)
        {
            var dataContext = ServiceLocator.GetService<IDataContext>();
            using (var session = dataContext.SessionFactory.OpenSession())
            {
                return session.CreateCriteria<PlayerListStoreItem>()
                    .Add(Restrictions.Eq("Id", playerListStoreId))
                    .SetMaxResults(1)
                    .UniqueResult<PlayerListStoreItem>();
            }
        }
    }
}
