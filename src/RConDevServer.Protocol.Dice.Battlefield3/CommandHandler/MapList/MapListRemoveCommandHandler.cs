namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.MapList
{
    using System;
    using Command;
    using Command.MapList;
    using Common;
    using Data;

    public class MapListRemoveCommandHandler : CommandHandlerBase<MapListRemoveCommand>
    {
        public override string Command
        {
            get { return Constants.COMMAND_MAP_LIST_REMOVE; }
        }

        public override bool OnCreatingResponse(PacketSession session, MapListRemoveCommand command, Packet requestPacket, Packet responsePacket)
        {
            var index = Convert.ToInt32(requestPacket.Words[1]);
            MapList mapList = session.Server.MapList;

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