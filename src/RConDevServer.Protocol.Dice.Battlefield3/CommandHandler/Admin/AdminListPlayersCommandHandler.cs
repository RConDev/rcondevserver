
namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    public class AdminListPlayersCommandHandler : CommandHandlerBase
    {
        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return Constants.COMMAND_ADMIN_LIST_PLAYERS; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            foreach (string word in session.Server.PlayerList.ToWords())
            {
                responsePacket.Words.Add(word);
            }
            return true;
        }

        #endregion
    }
}