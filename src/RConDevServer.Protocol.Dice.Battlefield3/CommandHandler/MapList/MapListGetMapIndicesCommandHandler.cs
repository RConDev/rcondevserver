﻿namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.MapList
{
    using System;
    using Command.MapList;
    using Common;
    using Data;

    public class MapListGetMapIndicesCommandHandler : CommandHandlerBase<MapListGetMapIndicesCommand>
    {
        public override string Command
        {
            get { return Constants.COMMAND_MAP_LIST_GET_MAP_INDICES; }
        }

        public override bool OnCreatingResponse(PacketSession session, MapListGetMapIndicesCommand command, Packet requestPacket, Packet responsePacket)
        {
            if (requestPacket.Words.Count == 1)
            {
                MapList mapList = session.Server.MapList;

                responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
                responsePacket.Words.Add(Convert.ToString(mapList.CurrentIndex));
                responsePacket.Words.Add(Convert.ToString(mapList.NextIndex));
            }
            else
            {
                this.ResponseInvalidArguments(responsePacket);
            }
            return true;
        }
    }
}