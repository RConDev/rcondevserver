
namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    public abstract class VarsCommandHandlerBase : CommandHandlerBase
    {
        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            if (requestPacket.Words.Count == 1)
            {
                return OnGetValue(session, responsePacket);
            }
            if (requestPacket.WordCount == 2)
            {
                return OnSetValue(session, requestPacket, responsePacket);
            }
            responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
            return true;
        }

        protected abstract bool OnGetValue(PacketSession session, Packet responsePacket);

        protected abstract bool OnSetValue(PacketSession session, Packet requestPacket, Packet responsePacket);
    }
}