using System;
using RConDevServer.Protocol.Dice.Battlefield3.Util;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    public class VarsIdleTimeOutCommandHandler : VarsCommandHandlerBase
    {
        public override string Command
        {
            get { return RConDevServer.Protocol.Dice.Battlefield3.Constants.COMMAND_VARS_IDLE_TIMEOUT; }
        }

        protected override bool OnGetValue(PacketSession session, Packet responsePacket)
        {
            var response = new[]
                               {
                                   RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_SUCCESS,
                                   Convert.ToString(session.Server.Vars[Command])
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