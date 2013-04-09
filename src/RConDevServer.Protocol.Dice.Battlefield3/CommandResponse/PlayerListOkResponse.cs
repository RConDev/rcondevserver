namespace RConDevServer.Protocol.Dice.Battlefield3.CommandResponse
{
    using System.Collections.Generic;
    using System.Linq;
    using Command.Admin;
    using Data;

    /// <summary>
    /// Implementation of <see cref="ICommandResponse"/> for <see cref="AdminListPlayersCommand"/>
    /// </summary>
    public class PlayerListOkResponse : OkResponse
    {
        /// <summary>
        /// Creates a new <see cref="PlayerListOkResponse"/> instance
        /// </summary>
        /// <param name="playerList"></param>
        /// <param name="includeGuid"></param>
        public PlayerListOkResponse(IPlayerList playerList = null, bool includeGuid = false)
        {
            this.PlayerList = playerList;
            this.IncludeGuid = includeGuid;
        }

        /// <summary>
        /// Gets if the <see cref="PlayerListOkResponse"/> includes the EA_GUIDs
        /// </summary>
        public bool IncludeGuid { get; private set; }

        /// <summary>
        /// gets the <see cref="IPlayerList"/> sent back within this response
        /// </summary>
        public IPlayerList PlayerList { get; private set; }

        /// <summary>
        /// Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<string> ToWords()
        {
            var words = base.ToWords().ToList();
            words.AddRange(this.PlayerList.ToWords(IncludeGuid));
            return words;
        }
    }
}