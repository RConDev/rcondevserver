using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Server
{
    public class ServerOnRoundOverPlayersEvent : IEvent
    {
        public PlayerList PlayerList { get; private set; }

        public ServerOnRoundOverPlayersEvent(PlayerList playerList)
        {
            PlayerList = playerList;
        }

        public string Event { get { return EventNames.ServerOnRoundOverPlayers; } }

        public IEnumerable<string> ToWords()
        {
            var words = new List<string> {Event};
            words.AddRange(PlayerList.ToWords());
            return words;
        }
    }
}
