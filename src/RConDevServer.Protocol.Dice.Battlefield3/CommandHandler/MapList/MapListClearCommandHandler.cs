namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.MapList
{
    using Command;
    using Command.MapList;
    using Common;

    public class MapListClearCommandHandler : CommandHandlerBase<MapListClearCommand>
    {
        public override string Command
        {
            get { return Constants.COMMAND_MAP_LIST_CLEAR; }
        }

        public override bool OnCreatingResponse(PacketSession session, MapListClearCommand command, Packet requestPacket, Packet responsePacket)
        {
            if (requestPacket.Words.Count == 1)
            {
                session.Server.MapList.Clear();
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