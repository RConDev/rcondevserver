namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.ReservedSlots
{
    using System;
    using Command;
    using Common;
    using Util;

    public class ReserverdSlotsListAggressiveJoinCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return CommandNames.ReservedSlotsListAggressiveJoin; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket,
                                                ICommand command)
        {
            if (requestPacket.WordCount == 2)
            {
                bool enabled = false;
                if (bool.TryParse(requestPacket.Words[1], out enabled))
                {
                    session.Server.ReservedSlots.IsAggressiveJoin = enabled;
                    return this.ResponseSuccess(responsePacket);
                }
                else
                {
                    return this.ResponseInvalidArguments(requestPacket);
                }
            }
            else if (requestPacket.WordCount == 1)
            {
                bool enabled = session.Server.ReservedSlots.IsAggressiveJoin;
                responsePacket.Words.AddRange(new[] {Constants.RESPONSE_SUCCESS, Convert.ToString(enabled)});
                return true;
            }
            else
            {
                return this.ResponseInvalidArguments(responsePacket);
            }
        }
    }
}