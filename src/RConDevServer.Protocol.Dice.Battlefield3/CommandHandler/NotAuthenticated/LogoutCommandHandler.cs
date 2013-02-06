namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.NotAuthenticated
{
    using Command;
    using Common;

    /// <summary>
    ///     Handles the Command "logout"
    /// </summary>
    public class LogoutCommandHandler : CommandHandlerBase
    {
        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return Constants.COMMAND_LOGOUT; }
        }

        public override bool OnCreatingResponse(PacketSession session, ICommand command, Packet requestPacket, Packet responsePacket)
        {
            session.IsAuthenticated = false;
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            return true;
        }

        #endregion
    }
}