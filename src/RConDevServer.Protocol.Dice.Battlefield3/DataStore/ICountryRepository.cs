namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    using System.Collections.Generic;
    using Data;
    using Interface;

    public interface ICountryRepository
    {
        IServiceLocator ServiceLocator { get; }

        IEnumerable<Country> GetAll();
    }
}