using RConDevServer.Protocol.Dice.Battlefield3.Event.Server;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.MapList
{
    using Command;

    public class MapListEndRoundCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return Constants.COMMAND_MAP_LIST_END_ROUND; }
        }

        public override bool OnCreatingResponse (PacketSession session, Packet requestPacket, Packet responsePacket, ICommand command)
        {
            if (requestPacket.Words.Count != 2)
            {
                return ResponseInvalidArguments(responsePacket);
            }

            var winningTeamIdString = requestPacket.Words[1];
            int winningTeamId;
            if (!int.TryParse(winningTeamIdString, out winningTeamId))
            {
                return ResponseInvalidArguments(responsePacket);
            }

            // send events
            AddEvent(new ServerOnRoundOverEvent(winningTeamId));
            AddEvent(new ServerOnRoundOverPlayersEvent(session.Server.PlayerList));
            AddEvent(new ServerOnRoundOverTeamScoresEvent(session.Server.TeamScores));
            
            return ResponseSuccess(responsePacket);
        }
    }
}
