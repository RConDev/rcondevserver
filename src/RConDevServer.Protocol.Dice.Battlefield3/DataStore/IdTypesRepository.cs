using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using RConDevServer.Protocol.Dice.Battlefield3.Data;
using RConDevServer.Protocol.Interface;

namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    public class IdTypesRepository : IIdTypeRepository
    {
        public IServiceLocator ServiceLocator { get; private set; }

        public IdTypesRepository(IServiceLocator serviceLocator)
        {
            ServiceLocator = serviceLocator;
        }

        public IEnumerable<IdType> GetAll()
        {
            var sessionFactory = this.ServiceLocator.GetService<IDataContext>().SessionFactory;
            using (var session = sessionFactory.OpenSession())
            {
                return session.CreateCriteria<IdType>().List<IdType>();
            }
        }
    }
}
