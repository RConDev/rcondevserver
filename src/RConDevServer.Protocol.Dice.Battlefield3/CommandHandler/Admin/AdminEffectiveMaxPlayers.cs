using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using Command;

    public class AdminEffectiveMaxPlayers : CommandHandlerBase
    {
        public override string Command { get { return Constants.COMMAND_ADMIN_EFFECTIVE_MAX_PLAYERS; } }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket, ICommand command)
        {
            if (requestPacket.Words.Count != 1)
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
                return true;
            }

            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            responsePacket.Words.Add(Convert.ToString(session.Server.ServerInfo.MaxPlayerCount));
            return true;
        }
    }
}
