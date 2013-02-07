namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.MapList
{
    using Command;
    using Command.MapList;
    using Common;
    using Data;

    public class MapListSetNextMapIndexCommandHandler : CommandHandlerBase<MapListSetNextMapIndexCommand>
    {
        public override string Command
        {
            get { return Constants.COMMAND_MAP_LIST_SET_NEXT_MAP_INDEX; }
        }

        public override bool OnCreatingResponse(PacketSession session, MapListSetNextMapIndexCommand command, Packet requestPacket, Packet responsePacket)
        {
            MapList mapList = session.Server.MapList;
            if (requestPacket.Words.Count == 2)
            {
                int index = 0;
                if (int.TryParse(requestPacket.Words[1], out index))
                {
                    if (index >= 0 && index < mapList.Count)
                    {
                        // setze den neuen index
                        mapList.NextIndex = index;
                        responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
                    }
                    else
                    {
                        responsePacket.Words.Add(Constants.RESPONSE_INVALID_MAP_INDEX);
                    }
                }
                else
                {
                    responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
                }
            }
            else
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
            }
            return true;
        }
    }
}