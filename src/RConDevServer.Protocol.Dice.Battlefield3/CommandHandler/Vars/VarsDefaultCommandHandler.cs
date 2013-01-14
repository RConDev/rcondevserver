namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using System;
    using Common;

    public abstract class VarsDefaultCommandHandler : VarsCommandHandlerBase
    {
        protected abstract object ConvertToValue(string valueString);

        protected override bool OnGetValue(PacketSession session, Packet responsePacket)
        {
            object value = session.Server.Vars[this.Command];
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            responsePacket.Words.Add(Convert.ToString(value));
            return true;
        }

        protected override bool OnSetValue(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            string valueString = requestPacket.Words[1];
            object value = this.ConvertToValue(valueString);
            if (value != null)
            {
                session.Server.Vars[this.Command] = value;
                responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            }
            else
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
            }
            return true;
        }
    }
}