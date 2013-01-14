namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    using System.Collections.Generic;
    using Data;
    using Interface;

    public interface IIdTypeRepository
    {
        IServiceLocator ServiceLocator { get; }

        IEnumerable<IdType> GetAll();
    }
}