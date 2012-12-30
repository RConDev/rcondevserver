using System.Collections.Generic;
using NHibernate;
using RConDevServer.Protocol.Dice.Battlefield3.Data;
using RConDevServer.Protocol.Interface;

namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    using NHibernate.Criterion;

    public class MapRepository : IMapRepository
    {
        public IServiceLocator ServiceLocator { get; private set; }

        public MapRepository(IServiceLocator serviceLocator)
        {
            this.ServiceLocator = serviceLocator;
        }

        public IList<Map> GetAll()
        {
            var sessionFactory = ServiceLocator.GetService<IDataContext>().SessionFactory;
            using (var session = sessionFactory.OpenSession())
            {
                return session.CreateCriteria<Map>().List<Map>();
            }
        }

        public Map FindByCode(string code)
        {
            var sessionFactory = ServiceLocator.GetService<IDataContext>().SessionFactory;
            using (var session = sessionFactory.OpenSession())
            {
                return session.CreateCriteria<Map>()
                    .Add(Restrictions.Eq("Code", code))
                    .SetMaxResults(1)
                    .UniqueResult<Map>();
            }
        }
    }
}
