using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    public class AdminKickPlayerCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return Constants.COMMAND_ADMIN_KICK_PLAYER; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            if (requestPacket.Words.Count > 3)
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
                return true;
            }

            
            var playerName = requestPacket.Words[1];

            var playerList = session.Server.PlayerList.Players;
            if (playerList.All(x => x.Name != playerName))
            {
                responsePacket.Words.Add(Constants.RESPONSE_PLAYER_NOT_FOUND);
                return true;
            }

            var reason = (requestPacket.Words.Count == 3) ? requestPacket.Words[2] : Constants.DEFAULT_KICK_REASON;
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            return true;
        }
    }
}
