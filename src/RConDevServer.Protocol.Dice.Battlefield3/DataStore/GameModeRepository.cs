using System.Collections.Generic;
using NHibernate;
using RConDevServer.Protocol.Dice.Battlefield3.Data;
using RConDevServer.Protocol.Interface;

namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    using NHibernate.Criterion;

    public class GameModeRepository : IGameModeRepository
    {
        public IServiceLocator ServiceLocator { get; private set; }

        public GameModeRepository(IServiceLocator serviceLocator)
        {
            ServiceLocator = serviceLocator;
        }

        public IList<GameMode> GetAll()
        {
            var sessionFactory = ServiceLocator.GetService<IDataContext>().SessionFactory;
            using (var session = sessionFactory.OpenSession())
            {
                return session.CreateCriteria<GameMode>().List<GameMode>();
            }
        }

        public GameMode FindByCode(string code)
        {
            var sessionFactory = ServiceLocator.GetService<IDataContext>().SessionFactory;
            using (var session = sessionFactory.OpenSession())
            {
                return session.CreateCriteria<GameMode>()
                    .Add(Restrictions.Eq("Code", code))
                    .SetMaxResults(1)
                    .UniqueResult<GameMode>();
            }
        }
    }
}
