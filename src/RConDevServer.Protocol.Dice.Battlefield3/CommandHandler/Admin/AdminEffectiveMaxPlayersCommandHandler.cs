namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using System;
    using Command;
    using Command.Admin;
    using CommandResponse;
    using Common;

    public class AdminEffectiveMaxPlayersCommandHandler : CommandHandlerBase<AdminEffectiveMaxPlayersCommand>
    {
        public override string Command
        {
            get { return CommandNames.AdminEffectiveMaxPlayers; }
        }

        public override ICommandResponse ProcessCommand(AdminEffectiveMaxPlayersCommand command, PacketSession session)
        {
            var response = new DecimalOkResponse(session.Server.ServerInfo.MaxPlayerCount);
            return response;
        }

        public override bool OnCreatingResponse(PacketSession session, AdminEffectiveMaxPlayersCommand command, Packet requestPacket, Packet responsePacket)
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