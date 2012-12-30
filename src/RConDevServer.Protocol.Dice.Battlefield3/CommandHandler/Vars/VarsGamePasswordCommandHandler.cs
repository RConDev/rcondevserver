using System;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using Data;

    public class VarsGamePasswordCommandHandler : ICanHandleClientCommands
    {
        #region ICanHandleClientCommands Members

        public string Command
        {
            get { return RConDevServer.Protocol.Dice.Battlefield3.Constants.COMMAND_VARS_GAMEPASSWORD; }
        }

        public bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            if (requestPacket.WordCount == 1)
            {
                // get the current password
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
                // set the password
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