namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Server
{
    using System.Collections.Generic;
    using Data;

    public class ServerOnRoundOverTeamScoresEvent : IEvent
    {
        public ServerOnRoundOverTeamScoresEvent(TeamScores teamScores)
        {
            this.TeamScores = teamScores;
        }

        public TeamScores TeamScores { get; private set; }

        public string Event
        {
            get { return EventNames.ServerOnRoundOverTeamScores; }
        }

        public IEnumerable<string> ToWords()
        {
            var words = new List<string>
                {
                    this.Event
                };
            words.AddRange(this.TeamScores.ToWords());
            return words;
        }
    }
}