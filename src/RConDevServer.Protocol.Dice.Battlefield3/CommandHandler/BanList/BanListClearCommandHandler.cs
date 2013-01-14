namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.BanList
{
    using Command;
    using Common;

    public class BanListClearCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return Constants.COMMAND_BAN_LIST_CLEAR; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket,
                                                ICommand command)
        {
            session.Server.BanList.Clear();
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            return true;
        }
    }
}