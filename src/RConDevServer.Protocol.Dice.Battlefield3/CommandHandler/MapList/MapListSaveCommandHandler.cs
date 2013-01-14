namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.MapList
{
    using Command;
    using Common;
    using Data;

    public class MapListSaveCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return Constants.COMMAND_MAP_LIST_SAVE; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket,
                                                ICommand command)
        {
            if (requestPacket.Words.Count != 1)
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
                return true;
            }

            session.Server.MapListStore.Clear();
            foreach (MapListItem mapListItem in session.Server.MapList.Items)
            {
                session.Server.MapListStore.Add(mapListItem);
            }

            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            return true;
        }
    }
}