namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.BanList
{
    using Command;
    using Common;

    public class BanListSaveCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return CommandNames.BanListSave; }
        }

        public override bool OnCreatingResponse(PacketSession session, ICommand command, Packet requestPacket, Packet responsePacket)
        {
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            return true;
        }
    }
}