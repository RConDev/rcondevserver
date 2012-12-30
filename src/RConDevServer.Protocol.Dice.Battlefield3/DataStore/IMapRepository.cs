using System.Collections.Generic;
using RConDevServer.Protocol.Dice.Battlefield3.Data;
using RConDevServer.Protocol.Interface;

namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    public interface IMapRepository
    {
        IServiceLocator ServiceLocator { get; }
        
        IList<Map> GetAll();
        
        Map FindByCode(string code);
    }
}