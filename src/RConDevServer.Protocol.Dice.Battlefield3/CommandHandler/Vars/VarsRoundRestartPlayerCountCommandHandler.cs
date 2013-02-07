namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using System;
    using Command.Vars;
    using Common;

    public class VarsRoundRestartPlayerCountCommandHandler
        : VarsCommandHandlerBase<VarsRoundRestartPlayerCountCommand, int?>
    {
        public override string Command
        {
            get { return Constants.COMMAND_VARS_ROUND_RESTART_PLAYER_COUNT; }
        }

        protected override bool OnGetValue(PacketSession session, Packet responsePacket)
        {
            object value = session.Server.Vars[this.Command];
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            responsePacket.Words.Add(Convert.ToString(value));
            return true;
        }

        protected override bool OnSetValue(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            throw new NotImplementedException();
        }
    }
}