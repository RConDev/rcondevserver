using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RConDevServer.Protocol.Dice.Battlefield3.Data;
using RConDevServer.Protocol.Interface;

namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    public class CountryRepository : ICountryRepository
    {
        public CountryRepository(IServiceLocator serviceLocator)
        {
            this.ServiceLocator = serviceLocator;
        }

        public IServiceLocator ServiceLocator { get; private set; }

        public IEnumerable<Country> GetAll()
        {
            var sessionFactory = this.ServiceLocator.GetService<IDataContext>().SessionFactory;
            using (var session = sessionFactory.OpenSession())
            {
                return session.CreateCriteria<Country>().List<Country>();
            }
        }
    }
}
