using System;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    public class VarsRankedCommandHandler : VarsCommandHandlerBase
    {
        public override string Command
        {
            get { return RConDevServer.Protocol.Dice.Battlefield3.Constants.COMMAND_VARS_RANKED; }
        }

        protected override bool OnGetValue(PacketSession session, Packet responsePacket)
        {
            bool isRanked = session.Server.ServerInfo.IsRanked;
            responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_SUCCESS);
            responsePacket.Words.Add(Convert.ToString(isRanked));
            return true;
        }

        protected override bool OnSetValue(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            string stringValue = requestPacket.Words[2];
            bool isRanked = false;
            if (bool.TryParse(stringValue, out isRanked))
            {
                session.Server.ServerInfo.IsRanked = isRanked;
                responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_SUCCESS);
                return true;
            }
            responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_INVALID_ARGUMENTS);
            return true;
        }
    }
}