namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    public class AdminCommandHandlers : CommandHandlers
    {
        public AdminCommandHandlers()
        {
            RegisterCommandHandler(new AdminHelpCommandHandler());
            RegisterCommandHandler(new AdminEventsEnabledCommandHandler());
            RegisterCommandHandler(new AdminListPlayersCommandHandler());
            RegisterCommandHandler(new AdminSayCommandHandler());
            RegisterCommandHandler(new AdminYellCommandHandler());
            RegisterCommandHandler(new AdminKickPlayerCommandHandler());
            this.RegisterCommandHandler(new AdminEffectiveMaxPlayers());
            this.RegisterCommandHandler(new AdminMovePlayerCommandHandler());
        }
    }
}