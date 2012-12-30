namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.BanList
{
    public class BanListCommandHandlers : CommandHandlers
    {
        public BanListCommandHandlers()
        {
            RegisterCommandHandler(new BanListListCommandHandler());
            RegisterCommandHandler(new BanListAddCommandHandler());
            RegisterCommandHandler(new BanListRemoveCommandHandler());
            RegisterCommandHandler(new BanListClearCommandHandler());
            RegisterCommandHandler(new BanListLoadCommandHandler());
            RegisterCommandHandler(new BanListSaveCommandHandler());
        }
    }
}