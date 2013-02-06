namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using Command;
    using Common;

    public class AdminListPlayersCommandHandler : CommandHandlerBase
    {
        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return CommandNames.AdminListPlayers; }
        }

        public override bool OnCreatingResponse(PacketSession session, ICommand command, Packet requestPacket, Packet responsePacket)
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