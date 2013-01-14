namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    using System.Collections.Generic;
    using System.Linq;

    public class GameModes : List<GameMode>
    {
        public GameModes()
        {
        }

        public GameModes(IEnumerable<GameMode> modes)
        {
            this.AddRange(modes);
        }

        #region Public Methods

        public static GameMode FindByCode(string modeCode)
        {
            return new GameModes().FirstOrDefault(x => x.Code == modeCode);
        }

        #endregion
    }
}