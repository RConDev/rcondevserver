using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.ReservedSlots
{
    using Command;

    public class ReservedSlotsListAddCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return Constants.COMMAND_RESERVED_SLOTS_LISTS_ADD; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket, ICommand command)
        {
            if (requestPacket.WordCount != 2)
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
                return true;
            }

            var playerName = requestPacket.Words[1];

            if (playerName.Contains(" "))
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_NAME);
                return true;
            }

            if (session.Server.ReservedSlots.Any(x => x.PlayerName == playerName))
            {
                responsePacket.Words.Add(Constants.RESPONSE_PLAYER_ALREADY_IN_LIST);
                return true;
            }

            session.Server.ReservedSlots.Add(playerName);
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            return true;
        }
    }
}
