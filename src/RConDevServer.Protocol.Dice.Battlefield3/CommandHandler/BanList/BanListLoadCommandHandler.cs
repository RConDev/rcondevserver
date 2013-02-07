namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.BanList
{
    using Command;
    using Command.BanList;
    using Common;

    public class BanListLoadCommandHandler : CommandHandlerBase<BanListLoadCommand>
    {
        public override string Command
        {
            get { return CommandNames.BanListLoad; }
        }

        public override bool OnCreatingResponse(PacketSession session, BanListLoadCommand command, Packet requestPacket, Packet responsePacket)
        {
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            return true;
        }
    }
}