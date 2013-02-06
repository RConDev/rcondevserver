﻿namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.ReservedSlots
{
    using Command;
    using Common;
    using Event;

    public class ReservedSlotsListClearCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return CommandNames.ReservedSlotsListClear; }
        }

        public override bool OnCreatingResponse(PacketSession session, ICommand command, Packet requestPacket, Packet responsePacket)
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