namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using System;
    using Command;
    using Common;

    public class AdminEffectiveMaxPlayers : CommandHandlerBase
    {
        public override string Command
        {
            get { return CommandNames.AdminEffectiveMaxPlayers; }
        }

        public override bool OnCreatingResponse(PacketSession session, ICommand command, Packet requestPacket, Packet responsePacket)
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