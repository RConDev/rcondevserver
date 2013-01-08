namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using Interface;

    public class AdminCommandHandlers : CommandHandlers
    {
        public AdminCommandHandlers(IServiceLocator serviceLocator)
        {
            RegisterCommandHandler(new AdminHelpCommandHandler());
            RegisterCommandHandler(new AdminEventsEnabledCommandHandler());
            RegisterCommandHandler(new AdminListPlayersCommandHandler());
            RegisterCommandHandler(new AdminSayCommandHandler());
            RegisterCommandHandler(new AdminYellCommandHandler());
            RegisterCommandHandler(new AdminKickPlayerCommandHandler(serviceLocator));
            this.RegisterCommandHandler(new AdminEffectiveMaxPlayers());
            this.RegisterCommandHandler(new AdminMovePlayerCommandHandler());
        }
    }
}