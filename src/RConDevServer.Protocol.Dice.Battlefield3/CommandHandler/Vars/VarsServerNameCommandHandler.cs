using System;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using Data;

    public class VarsServerNameCommandHandler : ICanHandleClientCommands
    {
        #region ICanHandleClientCommands Members

        public string Command
        {
            get { return RConDevServer.Protocol.Dice.Battlefield3.Constants.COMMAND_VARS_SERVERNAME; }
        }

        public bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            if (requestPacket.WordCount == 1)
            {
                // get the server name
                Vars vars = session.Server.Vars;
                if (vars.ContainsKey(Command))
                {
                    object value = vars[Command];
                    responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_SUCCESS);
                    responsePacket.Words.Add(Convert.ToString(value));
                }
                else
                {
                    responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_UNKNOWN_COMMAND);
                }
            }
            else if (requestPacket.WordCount == 2)
            {
                // set server name
                string valueToSet = requestPacket.Words[1];
                if (valueToSet.Length > 240)
                {
                    responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_TOO_LONG_NAME);
                }
                else
                {
                    session.Server.ServerInfo.ServerName = valueToSet;
                    responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_SUCCESS);
                }
            }
            else
            {
                responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_INVALID_ARGUMENTS);
            }
            return true;
        }

        #endregion
    }
}