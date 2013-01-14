namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    using System.Collections.Generic;
    using Data;
    using Interface;

    public interface IMapRepository
    {
        IServiceLocator ServiceLocator { get; }

        IList<Map> GetAll();

        Map FindByCode(string code);
    }
}