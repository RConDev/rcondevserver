using RConDevServer.Protocol.Dice.Battlefield3.Event;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.ReservedSlots
{
    using Command;

    public class ReservedSlotsListClearCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return Constants.COMMAND_RESERVED_SLOTS_LISTS_CLEAR; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket, ICommand command)
        {
            // invalid number of words
            if (requestPacket.Words.Count != 1)
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
                return true;
            }

            session.Server.ReservedSlots.Clear();
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            return true;
        }

        public override void AddEvent(IEvent anEvent)
        {
        }
    }
}
