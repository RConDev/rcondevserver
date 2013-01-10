
namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.MapList
{
    using Command;

    public class MapListClearCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return Constants.COMMAND_MAP_LIST_CLEAR; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket, ICommand command)
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
