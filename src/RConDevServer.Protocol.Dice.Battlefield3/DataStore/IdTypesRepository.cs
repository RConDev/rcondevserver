namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    using System.Collections.Generic;
    using Data;
    using Interface;
    using NHibernate;

    public class IdTypesRepository : IIdTypeRepository
    {
        public IdTypesRepository(IServiceLocator serviceLocator)
        {
            this.ServiceLocator = serviceLocator;
        }

        public IServiceLocator ServiceLocator { get; private set; }

        public IEnumerable<IdType> GetAll()
        {
            ISessionFactory sessionFactory = this.ServiceLocator.GetService<IDataContext>().SessionFactory;
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.CreateCriteria<IdType>().List<IdType>();
            }
        }
    }
}