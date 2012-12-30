using System;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    public abstract class VarsDefaultCommandHandler : VarsCommandHandlerBase
    {
        protected abstract object ConvertToValue(string valueString);

        protected override bool OnGetValue(PacketSession session, Packet responsePacket)
        {
            object value = session.Server.Vars[Command];
            responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_SUCCESS);
            responsePacket.Words.Add(Convert.ToString(value));
            return true;
        }

        protected override bool OnSetValue(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            string valueString = requestPacket.Words[1];
            object value = ConvertToValue(valueString);
            if (value != null)
            {
                session.Server.Vars[Command] = value;
                responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_SUCCESS);
            }
            else
            {
                responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_INVALID_ARGUMENTS);
            }
            return true;
        }
    }
}