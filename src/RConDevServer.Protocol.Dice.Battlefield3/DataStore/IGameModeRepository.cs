namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    using System.Collections.Generic;
    using Data;

    public interface IGameModeRepository
    {
        IList<GameMode> GetAll();
        GameMode FindByCode(string code);
    }
}