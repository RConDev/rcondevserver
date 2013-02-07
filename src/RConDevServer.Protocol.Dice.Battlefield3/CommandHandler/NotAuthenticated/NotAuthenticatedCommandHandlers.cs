namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.NotAuthenticated
{
    using Command;
    using Interface;

    public class NotAuthenticatedCommandHandlers: CommandHandlers
    {
        public NotAuthenticatedCommandHandlers(IServiceLocator serviceLocator)
        {
            this.ServiceLocator = serviceLocator;
            this.RegisterCommandHandler(new VersionCommandHandler());
            this.RegisterCommandHandler(new ServerInfoCommandHandler(serviceLocator));
            this.RegisterCommandHandler(new LoginPlainTextHandler());
            this.RegisterCommandHandler(new LoginHashedHandler());
            this.RegisterCommandHandler(new LogoutCommandHandler());
            this.RegisterCommandHandler(new ListPlayersCommandHandler());
        }

        public IServiceLocator ServiceLocator { get; set; }
    }
}