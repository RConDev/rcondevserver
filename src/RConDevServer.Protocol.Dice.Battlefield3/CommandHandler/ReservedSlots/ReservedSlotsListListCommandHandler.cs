using RConDevServer.Protocol.Dice.Battlefield3.Util;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.ReservedSlots
{
    public class ReservedSlotsListListCommandHandler : ICanHandleClientCommands
    {
        #region ICanHandleClientCommands Members

        public string Command
        {
            get { return Constants.COMMAND_RESERVED_SLOTS_LISTS_LIST; }
        }

        public bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket)
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

        #endregion
    }
}