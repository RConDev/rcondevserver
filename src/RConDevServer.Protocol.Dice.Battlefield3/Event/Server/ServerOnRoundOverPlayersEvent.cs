namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Server
{
    using System.Collections.Generic;
    using Data;

    public class ServerOnRoundOverPlayersEvent : IEvent
    {
        public ServerOnRoundOverPlayersEvent(PlayerList playerList)
        {
            this.PlayerList = playerList;
        }

        public PlayerList PlayerList { get; private set; }

        public string Event
        {
            get { return EventNames.ServerOnRoundOverPlayers; }
        }

        public IEnumerable<string> ToWords()
        {
            var words = new List<string> {this.Event};
            words.AddRange(this.PlayerList.ToWords());
            return words;
        }
    }
}