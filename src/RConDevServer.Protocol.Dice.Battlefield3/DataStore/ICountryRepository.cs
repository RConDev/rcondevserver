using System.Collections.Generic;
using RConDevServer.Protocol.Dice.Battlefield3.Data;
using RConDevServer.Protocol.Interface;

namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    public interface ICountryRepository
    {
        IServiceLocator ServiceLocator { get; }

        IEnumerable<Country> GetAll();
    }
}