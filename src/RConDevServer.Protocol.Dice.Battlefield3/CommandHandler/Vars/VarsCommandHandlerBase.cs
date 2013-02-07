namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using Command;
    using Common;

    public abstract class VarsCommandHandlerBase<TVarsCommand, TVarValuee> : CommandHandlerBase<TVarsCommand>
        where TVarsCommand : class, IVarsCommand<TVarValuee>
    {
        public override bool OnCreatingResponse(PacketSession session, TVarsCommand command, Packet requestPacket, Packet responsePacket)
        {
            if (requestPacket.Words.Count == 1)
            {
                return this.OnGetValue(session, responsePacket);
            }
            if (requestPacket.WordCount == 2)
            {
                return this.OnSetValue(session, requestPacket, responsePacket);
            }
            responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
            return true;
        }

        protected abstract bool OnGetValue(PacketSession session, Packet responsePacket);

        protected abstract bool OnSetValue(PacketSession session, Packet requestPacket, Packet responsePacket);
    }
}