﻿namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using System;
    using Command;
    using Command.Vars;
    using Common;
    using Data;

    public class VarsServerNameCommandHandler : CommandHandlerBase<VarsServerNameCommand>
    {
        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return Constants.COMMAND_VARS_SERVERNAME; }
        }

        public override bool OnCreatingResponse(PacketSession session, VarsServerNameCommand command, Packet requestPacket, Packet responsePacket)
        {
            if (requestPacket.WordCount == 1)
            {
                // get the server name
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
                // set server name
                string valueToSet = requestPacket.Words[1];
                if (valueToSet.Length > 240)
                {
                    responsePacket.Words.Add(Constants.RESPONSE_TOO_LONG_NAME);
                }
                else
                {
                    session.Server.ServerInfo.ServerName = valueToSet;
                    responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
                }
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