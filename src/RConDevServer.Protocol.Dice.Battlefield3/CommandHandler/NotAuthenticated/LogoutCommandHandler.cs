namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.NotAuthenticated
{
    using Command;
    using Common;
    using Tests.CommandFactory.NotAuthenticated;

    /// <summary>
    ///     Handles the Command "logout"
    /// </summary>
    public class LogoutCommandHandler : CommandHandlerBase<LogoutCommand>
    {
        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return Constants.COMMAND_LOGOUT; }
        }

        public override bool OnCreatingResponse(PacketSession session, LogoutCommand command, Packet requestPacket, Packet responsePacket)
        {
            session.IsAuthenticated = false;
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            return true;
        }

        #endregion
    }
}