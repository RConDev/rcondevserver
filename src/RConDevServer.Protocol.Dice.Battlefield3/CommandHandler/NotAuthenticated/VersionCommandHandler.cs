namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.NotAuthenticated
{
    using Command;
    using Common;

    public class VersionCommandHandler : CommandHandlerBase
    {
        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return Constants.COMMAND_VERSION; }
        }

        public override bool OnCreatingResponse(PacketSession session, ICommand command, Packet requestPacket, Packet responsePacket)
        {
            if (requestPacket.Words.Count == 1)
            {
                responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
                responsePacket.Words.Add(Constants.PROTOCOL_CODE);
                responsePacket.Words.Add(Constants.PROTOCOL_BUILD_NUM);
            }
            else
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
            }
            return true;
        }

        #endregion
    }
}