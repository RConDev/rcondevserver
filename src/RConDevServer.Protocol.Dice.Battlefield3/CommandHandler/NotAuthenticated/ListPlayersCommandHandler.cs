namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.NotAuthenticated
{
    using Command;
    using Common;

    /// <summary>
    ///     Handles the Command "listPlayers"
    /// </summary>
    public class ListPlayersCommandHandler : CommandHandlerBase
    {
        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return Constants.COMMAND_LIST_PLAYERS; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket,
                                                ICommand command)
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