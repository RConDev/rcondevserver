namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.MapList
{
    using Command;
    using Common;
    using Event.Server;

    public class MapListEndRoundCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return Constants.COMMAND_MAP_LIST_END_ROUND; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket,
                                                ICommand command)
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
            this.AddEvent(new ServerOnRoundOverEvent(winningTeamId));
            this.AddEvent(new ServerOnRoundOverPlayersEvent(session.Server.PlayerList));
            this.AddEvent(new ServerOnRoundOverTeamScoresEvent(session.Server.TeamScores));

            return this.ResponseSuccess(responsePacket);
        }
    }
}