namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.Admin;
    using Common;
    using Data;
    using Interface;

    public class AdminKickPlayerCommandHandler : CommandHandlerBase
    {
        public AdminKickPlayerCommandHandler(IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
        }

        public override string Command
        {
            get { return CommandNames.AdminKickPlayer; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket,
                                                ICommand command1)
        {
            var command = command1 as KickPlayerCommand;
            if (requestPacket.Words.Count > 3)
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
                return true;
            }

            IList<PlayerInfo> playerList = session.Server.PlayerList.Players;
            if (playerList.All(x => x.Name != command.SoldierName))
            {
                responsePacket.Words.Add(Constants.RESPONSE_PLAYER_NOT_FOUND);
                return true;
            }

            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            return true;
        }
    }
}