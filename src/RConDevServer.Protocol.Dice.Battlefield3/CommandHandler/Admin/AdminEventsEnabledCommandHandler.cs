namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using Command;
    using Command.Admin;
    using CommandResponse;

    public class AdminEventsEnabledCommandHandler : CommandHandlerBase<AdminEventsEnabledCommand>
    {
        #region ICommandHandler Members

        public override string Command
        {
            get { return CommandNames.AdminEventsEnabled; }
        }

        public override ICommandResponse ProcessCommand(AdminEventsEnabledCommand command,
                                                        IPacketSession session)
        {
            if (command.IsEnabled.HasValue)
            {
                // sets the value
                session.IsEventsEnabled = command.IsEnabled.Value;
                return new OkResponse();
            }

            return new BooleanOkResponse(session.IsEventsEnabled);
        }

        #endregion
    }
}