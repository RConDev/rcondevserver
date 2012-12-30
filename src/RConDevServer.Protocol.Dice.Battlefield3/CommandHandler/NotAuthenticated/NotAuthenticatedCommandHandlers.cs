using RConDevServer.Protocol.Interface;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.NotAuthenticated
{
    public class NotAuthenticatedCommandHandlers : CommandHandlers
    {
        public IServiceLocator ServiceLocator { get; set; }

        public NotAuthenticatedCommandHandlers(IServiceLocator serviceLocator)
        {
            ServiceLocator = serviceLocator;
            RegisterCommandHandler(new VersionCommandHandler());
            RegisterCommandHandler(new ServerInfoCommandHandler(serviceLocator));
            RegisterCommandHandler(new LoginPlainTextHandler());
            RegisterCommandHandler(new LoginHashedHandler());
            RegisterCommandHandler(new LogoutCommandHandler());
            RegisterCommandHandler(new ListPlayersCommandHandler());
        }
    }
}