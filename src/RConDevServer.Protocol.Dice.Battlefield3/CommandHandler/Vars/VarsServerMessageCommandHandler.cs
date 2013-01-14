namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using System;
    using Common;

    public class VarsServerMessageCommandHandler : VarsCommandHandlerBase
    {
        public override string Command
        {
            get { return Constants.COMMAND_VARS_SERVER_MESSAGE; }
        }

        protected override bool OnGetValue(PacketSession session, Packet responsePacket)
        {
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            responsePacket.Words.Add(Convert.ToString(session.Server.Vars[this.Command]));
            return true;
        }

        protected override bool OnSetValue(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            throw new NotImplementedException();
        }
    }
}