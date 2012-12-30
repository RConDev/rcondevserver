
namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    public abstract class VarsCommandHandlerBase : ICanHandleClientCommands
    {
        #region ICanHandleClientCommands Members

        public abstract string Command { get; }

        public virtual bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            if (requestPacket.Words.Count == 1)
            {
                return OnGetValue(session, responsePacket);
            }
            if (requestPacket.WordCount == 2)
            {
                return OnSetValue(session, requestPacket, responsePacket);
            }
            responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_INVALID_ARGUMENTS);
            return true;
        }

        #endregion

        protected abstract bool OnGetValue(PacketSession session, Packet responsePacket);

        protected abstract bool OnSetValue(PacketSession session, Packet requestPacket, Packet responsePacket);
    }
}