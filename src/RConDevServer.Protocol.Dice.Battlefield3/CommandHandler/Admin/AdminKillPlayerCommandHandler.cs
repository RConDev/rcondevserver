namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using System.Linq;
    using Command;
    using Common;

    public class AdminKillPlayerCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return CommandNames.AdminKillPlayer; }
        }

        public override bool OnCreatingResponse(PacketSession session, ICommand command, Packet requestPacket, Packet responsePacket)
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