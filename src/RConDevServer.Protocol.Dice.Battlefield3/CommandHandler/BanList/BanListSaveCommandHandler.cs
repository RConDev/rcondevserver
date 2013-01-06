namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.BanList
{
    public class BanListSaveCommandHandler : ICanHandleClientCommands
    {
        public string Command
        {
            get { return Constants.COMMAND_BAN_LIST_SAVE; }
        }

        public bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            return true;
        }

        public void OnProcessingCommand(Battlefield3Server server)
        {
        }
    }
}
