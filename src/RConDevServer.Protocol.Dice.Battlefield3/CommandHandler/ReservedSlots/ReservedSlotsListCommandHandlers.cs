namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.ReservedSlots
{
    public class ReservedSlotsListCommandHandlers : CommandHandlers
    {
        public ReservedSlotsListCommandHandlers()
        {
            RegisterCommandHandler(new ReservedSlotsListListCommandHandler());
            RegisterCommandHandler(new ReservedSlotsListAddCommandHandler());
            RegisterCommandHandler(new ReservedSlotsListRemoveCommandHandler());
            RegisterCommandHandler(new ReservedSlotsListClearCommandHandler());
            RegisterCommandHandler(new ReserverdSlotsListSaveCommandHandler());
            RegisterCommandHandler(new ReservedSlotsListLoadCommandHandler());
            RegisterCommandHandler(new ReserverdSlotsListAggressiveJoinCommandHandler());
        }
    }
}