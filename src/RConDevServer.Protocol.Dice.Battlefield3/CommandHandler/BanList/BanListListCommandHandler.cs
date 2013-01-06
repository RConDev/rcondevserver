﻿using System;
using RConDevServer.Protocol.Dice.Battlefield3.Util;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.BanList
{
    public class BanListListCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return Constants.COMMAND_BAN_LIST_LIST; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            var banList = session.Server.BanList;

            if (requestPacket.Words.Count == 2 
                && !string.IsNullOrEmpty(requestPacket.Words[1]) )
            {
                var index = Convert.ToInt32(requestPacket.Words[1]);
                responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
                StringListExtensions.AddRange(responsePacket.Words, banList.ToWords(index));
                return true;
            }

            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            StringListExtensions.AddRange(responsePacket.Words, session.Server.BanList.ToWords(0));
            return true;
        }
    }
}
