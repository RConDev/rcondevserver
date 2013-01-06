
namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.NotAuthenticated
{
    public class QuitCommandHandler : ICanHandleClientCommands
    {
        #region ICanHandleClientCommands Members

        public string Command
        {
            get { return Constants.COMMAND_QUIT; }
        }

        public bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            session.Dispose();
            return true;
        }

        public void OnProcessingCommand(Battlefield3Server server)
        {
            
        }

        #endregion
    }
}