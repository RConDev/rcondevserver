namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using System;
    using Common;
    using Util;

    public class VarsIdleTimeOutCommandHandler : VarsCommandHandlerBase
    {
        public override string Command
        {
            get { return Constants.COMMAND_VARS_IDLE_TIMEOUT; }
        }

        protected override bool OnGetValue(PacketSession session, Packet responsePacket)
        {
            var response = new[]
                {
                    Constants.RESPONSE_SUCCESS,
                    Convert.ToString(session.Server.Vars[this.Command])
                };
            StringListExtensions.AddRange(responsePacket.Words, response);
            return true;
        }

        protected override bool OnSetValue(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            throw new NotImplementedException();
        }
    }
}