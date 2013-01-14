namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using Interface;

    public class AdminCommandHandlers : CommandHandlers
    {
        public AdminCommandHandlers(IServiceLocator serviceLocator)
        {
            this.RegisterCommandHandler(new AdminHelpCommandHandler());
            this.RegisterCommandHandler(new AdminEventsEnabledCommandHandler());
            this.RegisterCommandHandler(new AdminListPlayersCommandHandler());
            this.RegisterCommandHandler(new AdminSayCommandHandler());
            this.RegisterCommandHandler(new AdminYellCommandHandler());
            this.RegisterCommandHandler(new AdminKickPlayerCommandHandler(serviceLocator));
            this.RegisterCommandHandler(new AdminEffectiveMaxPlayers());
            this.RegisterCommandHandler(new AdminMovePlayerCommandHandler());
        }
    }
}