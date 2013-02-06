namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.ReservedSlots
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Common;
    using Data;

    public class ReservedSlotsListLoadCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return CommandNames.ReservedSlotsListLoad; }
        }

        public override bool OnCreatingResponse(PacketSession session, ICommand command, Packet requestPacket, Packet responsePacket)
        {
            if (requestPacket.Words.Count != 1)
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
                return true;
            }

            IEnumerable<ReservedSlot> reservedSlotsFromStore = session.Server.ReservedSlotsStore.GetAll();
            foreach (ReservedSlot reservedSlot in reservedSlotsFromStore)
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