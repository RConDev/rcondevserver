namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    using System.Collections.Generic;
    using Data;
    using Interface;
    using NHibernate;
    using NHibernate.Criterion;

    public class GameModeRepository : IGameModeRepository
    {
        public GameModeRepository(IServiceLocator serviceLocator)
        {
            this.ServiceLocator = serviceLocator;
        }

        public IServiceLocator ServiceLocator { get; private set; }

        public IList<GameMode> GetAll()
        {
            ISessionFactory sessionFactory = this.ServiceLocator.GetService<IDataContext>().SessionFactory;
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.CreateCriteria<GameMode>().List<GameMode>();
            }
        }

        public GameMode FindByCode(string code)
        {
            ISessionFactory sessionFactory = this.ServiceLocator.GetService<IDataContext>().SessionFactory;
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.CreateCriteria<GameMode>()
                              .Add(Restrictions.Eq("Code", code))
                              .SetMaxResults(1)
                              .UniqueResult<GameMode>();
            }
        }
    }
}