namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using Command;
    using Common;
    using Data;

    public class AdminHelpCommandHandler : CommandHandlerBase
    {
        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return CommandNames.AdminHelp; }
        }

        public override bool OnCreatingResponse(PacketSession session, ICommand command1, Packet requestPacket, Packet responsePacket)
        {
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            foreach (string command in new Commands())
            {
                responsePacket.Words.Add(command);
            }
            return true;
        }

        #endregion
    }
}