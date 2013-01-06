
namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.MapList
{
    using System.Linq;

    public class MapListLoadCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return Constants.COMMAND_MAP_LIST_LOAD; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            var mapListItemsFromStore = session.Server.MapListStore.GetAll();
            foreach (var mapListItem in mapListItemsFromStore)
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
