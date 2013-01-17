namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.ReservedSlots
{
    using Command;
    using Common;
    using Event;
    using Util;

    public class ReservedSlotsListListCommandHandler : CommandHandlerBase
    {
        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return CommandNames.ReservedSlotsListList; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket,
                                                ICommand command)
        {
            int offset = 0;
            if (requestPacket.Words.Count == 2)
            {
                int.TryParse(requestPacket.Words[1], out offset);
            }
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            StringListExtensions.AddRange(responsePacket.Words, session.Server.ReservedSlots.ToWords(offset));
            return true;
        }

        public override void AddEvent(IEvent anEvent)
        {
        }

        #endregion
    }
}