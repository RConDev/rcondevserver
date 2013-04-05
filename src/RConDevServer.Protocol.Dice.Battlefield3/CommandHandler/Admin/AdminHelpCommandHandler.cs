namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using Command;
    using Command.Admin;
    using CommandResponse;

    public class AdminHelpCommandHandler : CommandHandlerBase<AdminHelpCommand>
    {
        public override string Command
        {
            get { return CommandNames.AdminHelp; }
        }

        public override ICommandResponse ProcessCommand(AdminHelpCommand command, IPacketSession session)
        {
            return new StringListOkResponse(CommandNames.GetAll());
        }
    }
}