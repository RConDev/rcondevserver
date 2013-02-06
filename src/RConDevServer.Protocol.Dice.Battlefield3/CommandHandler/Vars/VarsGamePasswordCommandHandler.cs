namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using System;
    using Command;
    using Common;
    using Data;

    public class VarsGamePasswordCommandHandler : CommandHandlerBase
    {
        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return Constants.COMMAND_VARS_GAMEPASSWORD; }
        }

        public override bool OnCreatingResponse(PacketSession session, ICommand command, Packet requestPacket, Packet responsePacket)
        {
            if (requestPacket.WordCount == 1)
            {
                // get the current password
                Vars vars = session.Server.Vars;
                if (vars.ContainsKey(this.Command))
                {
                    object value = vars[this.Command];
                    responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
                    responsePacket.Words.Add(Convert.ToString(value));
                }
                else
                {
                    responsePacket.Words.Add(Constants.RESPONSE_UNKNOWN_COMMAND);
                }
            }
            else if (requestPacket.WordCount == 2)
            {
                // set the password
            }
            else
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
            }
            return true;
        }

        #endregion
    }
}