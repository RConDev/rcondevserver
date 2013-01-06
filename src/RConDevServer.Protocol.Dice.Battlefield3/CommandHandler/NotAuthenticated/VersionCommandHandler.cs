
namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.NotAuthenticated
{
    public class VersionCommandHandler : ICanHandleClientCommands
    {
        #region ICanHandleClientCommands Members

        public string Command
        {
            get { return RConDevServer.Protocol.Dice.Battlefield3.Constants.COMMAND_VERSION; }
        }

        public bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            if (requestPacket.Words.Count == 1)
            {
                responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
                responsePacket.Words.Add(Constants.PROTOCOL_CODE);
                responsePacket.Words.Add(Constants.PROTOCOL_BUILD_NUM);
            }
            else
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
            }
            return true;
        }

        public void OnProcessingCommand(Battlefield3Server server)
        {
            
        }

        #endregion
    }
}