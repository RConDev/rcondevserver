namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.ReservedSlots
{
    using System.Linq;
    using Command;
    using Common;

    public class ReservedSlotsListAddCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return CommandNames.ReservedSlotsListAdd; }
        }

        public override bool OnCreatingResponse(PacketSession session, ICommand command, Packet requestPacket, Packet responsePacket)
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