namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.NotAuthenticated
{
    using Command;
    using Command.NotAuthenticated;
    using Common;

    public class VersionCommandHandler : CommandHandlerBase<VersionCommand>
    {
        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return Constants.COMMAND_VERSION; }
        }

        public override bool OnCreatingResponse(PacketSession session, VersionCommand command, Packet requestPacket, Packet responsePacket)
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