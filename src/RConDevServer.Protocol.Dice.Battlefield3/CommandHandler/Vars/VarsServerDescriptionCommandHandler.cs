namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using System;
    using Command.Vars;
    using Common;

    public class VarsServerDescriptionCommandHandler : VarsCommandHandlerBase<VarsServerDescriptionCommand, string>
    {
        public override string Command
        {
            get { return Constants.COMMAND_VARS_SERVER_DESCRIPTION; }
        }

        protected override bool OnGetValue(PacketSession session, Packet responsePacket)
        {
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            responsePacket.Words.Add(session.Server.ServerDescription);
            return true;
        }

        protected override bool OnSetValue(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            throw new NotImplementedException();
        }
    }
}