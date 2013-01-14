namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.BanList
{
    using Command;
    using Common;

    public class BanListSaveCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return Constants.COMMAND_BAN_LIST_SAVE; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket,
                                                ICommand command)
        {
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            return true;
        }
    }
}