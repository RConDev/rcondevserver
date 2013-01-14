namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    using System.Collections.Generic;
    using Data;
    using Interface;
    using NHibernate;
    using NHibernate.Criterion;

    public class MapRepository : IMapRepository
    {
        public MapRepository(IServiceLocator serviceLocator)
        {
            this.ServiceLocator = serviceLocator;
        }

        public IServiceLocator ServiceLocator { get; private set; }

        public IList<Map> GetAll()
        {
            ISessionFactory sessionFactory = this.ServiceLocator.GetService<IDataContext>().SessionFactory;
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.CreateCriteria<Map>().List<Map>();
            }
        }

        public Map FindByCode(string code)
        {
            ISessionFactory sessionFactory = this.ServiceLocator.GetService<IDataContext>().SessionFactory;
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.CreateCriteria<Map>()
                              .Add(Restrictions.Eq("Code", code))
                              .SetMaxResults(1)
                              .UniqueResult<Map>();
            }
        }
    }
}