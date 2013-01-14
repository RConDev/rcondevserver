namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    using System.Collections.Generic;
    using Data;
    using Interface;
    using NHibernate;

    public class CountryRepository : ICountryRepository
    {
        public CountryRepository(IServiceLocator serviceLocator)
        {
            this.ServiceLocator = serviceLocator;
        }

        public IServiceLocator ServiceLocator { get; private set; }

        public IEnumerable<Country> GetAll()
        {
            ISessionFactory sessionFactory = this.ServiceLocator.GetService<IDataContext>().SessionFactory;
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.CreateCriteria<Country>().List<Country>();
            }
        }
    }
}