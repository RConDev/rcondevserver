namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.ReservedSlots
{
    using Command;
    using Command.ReservedSlotsList;
    using Common;
    using Data;

    public class ReservedSlotsListSaveCommandHandler : CommandHandlerBase<ReservedSlotsListSaveCommand>
    {
        public override string Command
        {
            get { return CommandNames.ReservedSlotsListSave; }
        }

        public override bool OnCreatingResponse(PacketSession session, ReservedSlotsListSaveCommand command, Packet requestPacket, Packet responsePacket)
        {
            if (requestPacket.Words.Count != 1)
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
                return true;
            }

            session.Server.ReservedSlotsStore.Clear();
            foreach (ReservedSlot reservedSlot in session.Server.ReservedSlots)
            {
                session.Server.ReservedSlotsStore.Add(reservedSlot);
            }
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            return true;
        }
    }
}