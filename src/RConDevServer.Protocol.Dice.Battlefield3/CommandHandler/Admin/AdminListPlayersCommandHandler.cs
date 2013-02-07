namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using Command;
    using Command.Admin;
    using Common;

    public class AdminListPlayersCommandHandler : CommandHandlerBase<AdminListPlayersCommand>
    {
        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return CommandNames.AdminListPlayers; }
        }

        public override bool OnCreatingResponse(PacketSession session, AdminListPlayersCommand command, Packet requestPacket, Packet responsePacket)
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