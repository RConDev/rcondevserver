namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.ReservedSlots
{
    using Command;

    public class ReservedSlotsListCommandHandlers : CommandHandlers
    {
        public ReservedSlotsListCommandHandlers()
        {
            this.RegisterCommandHandler(new ReservedSlotsListListCommandHandler());
            this.RegisterCommandHandler(new ReservedSlotsListAddCommandHandler());
            this.RegisterCommandHandler(new ReservedSlotsListRemoveCommandHandler());
            this.RegisterCommandHandler(new ReservedSlotsListClearCommandHandler());
            this.RegisterCommandHandler(new ReservedSlotsListSaveCommandHandler());
            this.RegisterCommandHandler(new ReservedSlotsListLoadCommandHandler());
            this.RegisterCommandHandler(new ReservedSlotsListAggressiveJoinCommandHandler());
        }
    }
}