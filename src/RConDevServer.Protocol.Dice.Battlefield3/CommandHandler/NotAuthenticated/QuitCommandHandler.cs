namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.NotAuthenticated
{
    using Command;
    using Command.NotAuthenticated;
    using Common;

    public class QuitCommandHandler : CommandHandlerBase<QuitCommand>
    {
        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return Constants.COMMAND_QUIT; }
        }

        public override bool OnCreatingResponse(PacketSession session, QuitCommand command, Packet requestPacket, Packet responsePacket)
        {
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            session.Dispose();
            return true;
        }

        #endregion
    }
}