namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using System;
    using Common;

    public class VarsPremiumStatusCommandHandler : VarsCommandHandlerBase
    {
        public override string Command
        {
            get { return Constants.COMMAND_VARS_PREMIUM_STATUS; }
        }

        protected override bool OnGetValue(PacketSession session, Packet responsePacket)
        {
            object varValue = session.Server.Vars[this.Command];
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            responsePacket.Words.Add(varValue.ToString());

            return true;
        }

        protected override bool OnSetValue(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            throw new NotImplementedException();
        }
    }
}