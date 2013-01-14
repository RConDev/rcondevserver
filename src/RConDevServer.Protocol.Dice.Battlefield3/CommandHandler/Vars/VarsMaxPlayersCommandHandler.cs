namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using System;
    using Common;
    using Util;

    public class VarsMaxPlayersCommandHandler : VarsCommandHandlerBase
    {
        public override string Command
        {
            get { return Constants.COMMAND_VARS_MAX_PLAYERS; }
        }

        protected override bool OnGetValue(PacketSession session, Packet responsePacket)
        {
            var response = new[]
                {
                    Constants.RESPONSE_SUCCESS,
                    Convert.ToString(session.Server.ServerInfo.MaxPlayerCount)
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