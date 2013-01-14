namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.NotAuthenticated
{
    using Command;
    using Common;

    public class QuitCommandHandler : CommandHandlerBase
    {
        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return Constants.COMMAND_QUIT; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket,
                                                ICommand command)
        {
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            session.Dispose();
            return true;
        }

        #endregion
    }
}