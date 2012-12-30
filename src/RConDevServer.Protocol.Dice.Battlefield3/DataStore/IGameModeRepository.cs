using System.Collections.Generic;
using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    public interface IGameModeRepository
    {
        IList<GameMode> GetAll();
        GameMode FindByCode(string code);
    }
}