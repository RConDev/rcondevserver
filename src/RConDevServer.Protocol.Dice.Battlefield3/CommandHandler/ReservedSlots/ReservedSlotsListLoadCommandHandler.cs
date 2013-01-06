using System.Linq;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.ReservedSlots
{
    public class ReservedSlotsListLoadCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return Constants.COMMAND_RESERVED_SLOTS_LIST_LOAD; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            if (requestPacket.Words.Count != 1)
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
                return true;
            }

            var reservedSlotsFromStore = session.Server.ReservedSlotsStore.GetAll();
            foreach (var reservedSlot in reservedSlotsFromStore)
            {
                if (session.Server.ReservedSlots.Any(x => x.PlayerName == reservedSlot.PlayerName))
                {
                    responsePacket.Words.Add(Constants.RESPONSE_PLAYER_ALREADY_IN_LIST);
                    return true;
                }
                session.Server.ReservedSlots.Add(reservedSlot.PlayerName);
            }

            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            return true;
        }
    }
}
