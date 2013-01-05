using RConDevServer.Protocol.Dice.Battlefield3.Event.Server;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.MapList
{
    public class MapListEndRoundCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return Constants.COMMAND_MAP_LIST_END_ROUND; }
        }

        public override bool OnCreatingResponse (PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            if (requestPacket.Words.Count != 2)
            {
                return this.ResponseInvalidArguments(responsePacket);
            }

            var winningTeamIdString = requestPacket.Words[1];
            int winningTeamId;
            if (!int.TryParse(winningTeamIdString, out winningTeamId))
            {
                return this.ResponseInvalidArguments(responsePacket);
            }

            // send events
            var roundOverEvent = new ServerOnRoundOverEvent(winningTeamId);
            session.Server.PublishEvent(roundOverEvent);

            var roundOverPlayersEvent = new ServerOnRoundOverPlayersEvent(session.Server.PlayerList);
            session.Server.PublishEvent(roundOverPlayersEvent);

            var roundOverTeamScoresEvent = new ServerOnRoundOverTeamScoresEvent(session.Server.TeamScores);
            session.Server.PublishEvent(roundOverTeamScoresEvent);

            return this.ResponseSuccess(responsePacket);
        }
    }
}
