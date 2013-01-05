using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    public class AdminHelpCommandHandler : ICanHandleClientCommands
    {
        #region ICanHandleClientCommands Members

        public string Command
        {
            get { return Constants.COMMAND_ADMIN_HELP; }
        }

        public bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket)
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