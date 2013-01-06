using System;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.MapList
{
    public class MapListRemoveCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return Constants.COMMAND_MAP_LIST_REMOVE; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            var index = Convert.ToInt32(requestPacket.Words[1]);
            var mapList = session.Server.MapList;

            if (index > 0 || index < mapList.Count)
            {
                mapList.RemoveAt(index);
                responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            }
            else
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_MAP_INDEX);
            }
            return true;
        }
    }
}
