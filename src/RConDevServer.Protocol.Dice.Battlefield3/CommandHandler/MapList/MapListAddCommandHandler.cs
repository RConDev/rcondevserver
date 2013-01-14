namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.MapList
{
    using System;
    using System.Linq;
    using Command;
    using Common;
    using Data;

    public class MapListAddCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return Constants.COMMAND_MAP_LIST_ADD; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket,
                                                ICommand command)
        {
            // Check the given map code
            Map map = session.Server.AvailableMaps.FirstOrDefault(x => x.Code == requestPacket.Words[1]);
            if (map == null)
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_MAP);
                return true;
            }

            // check the given game mode code
            GameMode gameMode = session.Server.AvailableModes.FirstOrDefault(x => x.Code == requestPacket.Words[2]);
            if (gameMode == null)
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_GAME_MODE_ON_MAP);
                return true;
            }

            // check game mode available for map
            if (map.SupportedModes.All(x => x.Code != gameMode.Code))
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_GAME_MODE_ON_MAP);
                return true;
            }

            // check rounds given
            var rounds = Convert.ToInt32(requestPacket.Words[3]);
            if (rounds < 1)
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ROUNDS_PER_MAP);
                return true;
            }

            var mapListItem = new MapListItem
                {
                    Map = map,
                    Mode = gameMode,
                    Rounds = rounds,
                };

            MapList mapList = session.Server.MapList;
            if (requestPacket.Words.Count <= 4)
            {
                mapList.Add(mapListItem);
            }
            else
            {
                // check the index given
                var index = Convert.ToInt32(requestPacket.Words[4]);
                if (index <= 0 || index >= mapList.Count)
                {
                    mapList.Insert(index, mapListItem);
                }
                else
                {
                    responsePacket.Words.Add(Constants.RESPONSE_INVALID_MAP_INDEX);
                    return true;
                }
            }
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            return true;
        }
    }
}