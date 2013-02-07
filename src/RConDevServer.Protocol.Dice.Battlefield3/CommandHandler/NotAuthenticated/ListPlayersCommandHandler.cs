namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.NotAuthenticated
{
    using Command;
    using Command.NotAuthenticated;
    using Common;

    /// <summary>
    ///     Handles the Command "listPlayers"
    /// </summary>
    public class ListPlayersCommandHandler : CommandHandlerBase<ListPlayersCommand>
    {
        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return Constants.COMMAND_LIST_PLAYERS; }
        }

        public override bool OnCreatingResponse(PacketSession session, ListPlayersCommand command, Packet requestPacket, Packet responsePacket)
        {
            // create a default list not regarding the player subset
            foreach (string word in session.Server.PlayerList.ToWords(false))
            {
                responsePacket.Words.Add(word);
            }
            return true;
        }

        #endregion
    }
}