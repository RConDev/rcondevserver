namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.BanList
{
    using Command;
    using Command.BanList;
    using Common;

    public class BanListClearCommandHandler : CommandHandlerBase<BanListClearCommand>
    {
        public override string Command
        {
            get { return CommandNames.BanListClear; }
        }

        public override bool OnCreatingResponse(PacketSession session, BanListClearCommand command, Packet requestPacket, Packet responsePacket)
        {
            session.Server.BanList.Clear();
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            return true;
        }
    }
}