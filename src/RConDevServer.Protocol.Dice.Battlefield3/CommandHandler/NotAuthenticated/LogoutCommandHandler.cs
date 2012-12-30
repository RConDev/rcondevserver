
namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.NotAuthenticated
{
    /// <summary>
    /// Handles the Command "logout"
    /// </summary>
    public class LogoutCommandHandler : ICanHandleClientCommands
    {
        #region ICanHandleClientCommands Members

        public string Command
        {
            get { return RConDevServer.Protocol.Dice.Battlefield3.Constants.COMMAND_LOGOUT; }
        }

        public bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            session.IsAuthenticated = false;
            responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_SUCCESS);
            return true;
        }

        #endregion
    }
}