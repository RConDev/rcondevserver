namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.MapList
{
    using System.Collections.Generic;
    using Command;
    using Command.MapList;
    using Common;
    using Data;

    public class MapListLoadCommandHandler : CommandHandlerBase<MapListLoadCommand>
    {
        public override string Command
        {
            get { return Constants.COMMAND_MAP_LIST_LOAD; }
        }

        public override bool OnCreatingResponse(PacketSession session, MapListLoadCommand command, Packet requestPacket, Packet responsePacket)
        {
            IList<MapListItem> mapListItemsFromStore = session.Server.MapListStore.GetAll();
            foreach (MapListItem mapListItem in mapListItemsFromStore)
            {
                ////if (session.Server.ReservedSlots.Any(x => x.PlayerName == reservedSlot.PlayerName))
                ////{
                ////    responsePacket.Words.Add(Constants.RESPONSE_PLAYER_ALREADY_IN_LIST);
                ////    return true;
                ////}
                session.Server.MapList.Add(mapListItem);
            }

            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            return true;
        }
    }
}