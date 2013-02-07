namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.MapList
{
    using Command;

    public class MapListCommandHandlers : CommandHandlers

    {
        public MapListCommandHandlers()
        {
            this.RegisterCommandHandler( new MapListListCommandHandler());
            this.RegisterCommandHandler( new MapListLoadCommandHandler());
            this.RegisterCommandHandler( new MapListSaveCommandHandler());
            this.RegisterCommandHandler( new MapListAddCommandHandler());
            this.RegisterCommandHandler( new MapListRemoveCommandHandler());
            this.RegisterCommandHandler( new MapListClearCommandHandler());
            this.RegisterCommandHandler( new MapListSetNextMapIndexCommandHandler());
            this.RegisterCommandHandler( new MapListGetMapIndicesCommandHandler());
            this.RegisterCommandHandler( new MapListGetRoundsCommandHandler());
            this.RegisterCommandHandler( new MapListRunNextRoundCommandHandler());
            this.RegisterCommandHandler( new MapListEndRoundCommandHandler());
        }
    }
}