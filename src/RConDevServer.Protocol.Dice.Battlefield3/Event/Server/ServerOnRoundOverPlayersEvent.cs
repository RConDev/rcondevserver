using System.Collections.Generic;
using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Server
{
    public class ServerOnRoundOverPlayersEvent : IEvent
    {
        public ServerOnRoundOverPlayersEvent(PlayerList playerList)
        {
            PlayerList = playerList;
        }

        public PlayerList PlayerList { get; private set; }

        public string Event
        {
            get { return EventNames.ServerOnRoundOverPlayers; }
        }

        public IEnumerable<string> ToWords()
        {
            var words = new List<string> {Event};
            words.AddRange(PlayerList.ToWords());
            return words;
        }
    }
}