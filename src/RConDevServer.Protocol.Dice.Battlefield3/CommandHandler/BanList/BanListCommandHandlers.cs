namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.BanList
{
    using Command;

    public class BanListCommandHandlers : CommandHandlers
    {
        public BanListCommandHandlers()
        {
            this.RegisterCommandHandler(new BanListListCommandHandler());
            this.RegisterCommandHandler(new BanListAddCommandHandler());
            this.RegisterCommandHandler(new BanListRemoveCommandHandler());
            this.RegisterCommandHandler(new BanListClearCommandHandler());
            this.RegisterCommandHandler(new BanListLoadCommandHandler());
            this.RegisterCommandHandler(new BanListSaveCommandHandler());
        }
    }
}