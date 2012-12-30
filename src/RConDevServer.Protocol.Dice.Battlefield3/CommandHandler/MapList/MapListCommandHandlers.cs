namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.MapList
{
    public class MapListCommandHandlers : CommandHandlers
    {
        public MapListCommandHandlers()
        {
            RegisterCommandHandler(new MapListListCommandHandler());
            RegisterCommandHandler(new MapListLoadCommandHandler());
            RegisterCommandHandler(new MapListSaveCommandHandler());
            RegisterCommandHandler(new MapListAddCommandHandler());
            RegisterCommandHandler(new MapListRemoveCommandHandler());
            RegisterCommandHandler(new MapListClearCommandHandler());
            RegisterCommandHandler(new MapListSetNextMapIndexCommandHandler());
            RegisterCommandHandler(new MapListGetMapIndicesCommandHandler());
            RegisterCommandHandler(new MapListGetRoundsCommandHandler());
            RegisterCommandHandler(new MapListRunNextRoundCommandHandler());
            this.RegisterCommandHandler(new MapListEndRoundCommandHandler());
        }
    }
}