namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using Command;
    using Common;

    public class VarsBannerUrlCommandHandler : CommandHandlerBase
    {
        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return Constants.COMMAND_VARS_BANNER_URL; }
        }

        public override bool OnCreatingResponse(PacketSession session, ICommand command, Packet requestPacket, Packet responsePacket)
        {
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            responsePacket.Words.Add(string.Empty);
            return true;
        }

        #endregion
    }
}