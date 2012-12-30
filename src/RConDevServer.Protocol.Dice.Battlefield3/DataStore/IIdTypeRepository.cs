using System.Collections.Generic;
using RConDevServer.Protocol.Dice.Battlefield3.Data;
using RConDevServer.Protocol.Interface;

namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    public interface IIdTypeRepository
    {
        IServiceLocator ServiceLocator { get; }
        
        IEnumerable<IdType> GetAll();
    }
}