namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.MapList
{
    using Command;
    using Command.MapList;
    using Common;

    public class MapListRunNextRoundCommandHandler : CommandHandlerBase<MapListRunNextRoundCommand>
    {
        public override string Command
        {
            get { return Constants.COMMAND_MAP_LIST_RUN_NEXT_ROUND; }
        }

        public override bool OnCreatingResponse(PacketSession session, MapListRunNextRoundCommand command, Packet requestPacket, Packet responsePacket)
        {
            if (requestPacket.Words.Count == 1)
            {
                session.Server.MapList.NextRound();
                responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            }
            else
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
            }
            return true;
        }
    }
}