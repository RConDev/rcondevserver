namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.ReservedSlots
{
    using System.Linq;
    using Command;
    using Common;

    public class ReservedSlotsListRemoveCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return CommandNames.ReservedSlotsListRemove; }
        }

        public override bool OnCreatingResponse(PacketSession session, ICommand command, Packet requestPacket, Packet responsePacket)
        {
            // incorrect number of parameters
            if (requestPacket.Words.Count != 2)
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
                return true;
            }

            // player does not exist in vip list
            var playerName = requestPacket.Words[1];
            if (session.Server.ReservedSlots.All(x => x.PlayerName != playerName))
            {
                responsePacket.Words.Add(Constants.RESPONSE_PLAYER_NOT_IN_LIST);
                return true;
            }

            session.Server.ReservedSlots.Remove(playerName);
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            return true;
        }
    }
}