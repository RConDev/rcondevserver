using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    public class GameModes : List<GameMode>
    {
        

        public GameModes()
        {
        }

        public GameModes(IEnumerable<GameMode> modes )
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
