using System;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.NotAuthenticated
{
    public class LoginPlainTextHandler : CommandHandlerBase
    {
        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return Constants.COMMAND_LOGIN_PLAIN_TEXT; }
        }

        public override bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            if (string.Equals(requestPacket.Words[0],
                              Constants.COMMAND_LOGIN_PLAIN_TEXT,
                              StringComparison.InvariantCultureIgnoreCase))
            {
                if (requestPacket.Words.Count == 2 && requestPacket.Words[1] != string.Empty)
                {
                    responsePacket.Words.Clear();
                    if (requestPacket.Words[1] != session.Server.Password)
                    {
                        responsePacket.Words.Add("InvalidPassword");
                    }
                    else
                    {
                        responsePacket.Words.Add("OK");
                        session.IsAuthenticated = true;
                    }
                }
                else
                {
                    responsePacket.Words.Add("PasswordNotSet");
                }
                return true;
            }
            return false;
        }

        #endregion
    }
}