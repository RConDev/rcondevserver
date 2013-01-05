using System.Collections.Generic;
using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Server
{
    public class ServerOnRoundOverTeamScoresEvent : IEvent
    {
        public TeamScores TeamScores { get; private set; }

        public ServerOnRoundOverTeamScoresEvent(TeamScores teamScores)
        {
            TeamScores = teamScores;
        }

        public string Event { get { return EventNames.ServerOnRoundOverTeamScores; } }
        
        public IEnumerable<string> ToWords()
        {
            var words = new List<string>
                {
                    Event
                };
            words.AddRange(TeamScores.ToWords());
            return words;
        }
    }
}
