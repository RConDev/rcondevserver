using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using Command;

    public class AdminHelpCommandHandler : CommandHandlerBase
    {
        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return Constants.COMMAND_ADMIN_HELP; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket, ICommand command1)
        {
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            foreach (string command in new Commands())
            {
                responsePacket.Words.Add(command);
            }
            return true;
        }

        #endregion
    }
}