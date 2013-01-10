using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using Command;

    public class AdminKillPlayerCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return Constants.COMMAND_ADMIN_KILL_PLAYER; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket, ICommand command)
        {
            if (requestPacket.Words.Count != 2)
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
                return true;
            }

            var playerName = requestPacket.Words[1];
            var playerList = session.Server.PlayerList.Players;
            if (playerList.All(x => x.Name != playerName))
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_PLAYER_NAME);
                return true;
            }

            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            return true;
        }
    }
}
