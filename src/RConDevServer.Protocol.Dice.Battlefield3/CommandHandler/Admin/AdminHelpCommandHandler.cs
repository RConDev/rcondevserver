namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using Command;
    using CommandFactory.Admin;
    using Data;

    public class AdminHelpCommandHandler : CommandHandlerBase
    {
        public AdminHelpCommandHandler() : base(null, new HelpCommandFactory())
        {
        }

        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return Constants.COMMAND_ADMIN_HELP; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket,
                                                ICommand command1)
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