using System;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.NotAuthenticated
{
    using Util;

    public class LoginHashedHandler : ICanHandleClientCommands
    {
        #region ICanHandleClientCommands Members

        public string Command
        {
            get { return RConDevServer.Protocol.Dice.Battlefield3.Constants.COMMAND_LOGIN_HASHED; }
        }

        public bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            if (string.Equals(requestPacket.Words[0], RConDevServer.Protocol.Dice.Battlefield3.Constants.COMMAND_LOGIN_HASHED,
                              StringComparison.InvariantCultureIgnoreCase))
            {
                #region Receiving Hash Value

                if (requestPacket.Words.Count == 1)
                {
                    responsePacket.Words.Add("OK");
                    responsePacket.Words.Add(session.HashValue);
                    return true;
                }

                #endregion

                #region Processing Login

                if (requestPacket.Words.Count == 2)
                {
                    string currentPassword = session.Server.Password;
                    string hashedSaltedPassword =
                        PasswordHashService.GeneratePasswordHash(
                            HexConverterService.HashToByteArray(session.HashValue), currentPassword);
                    string passwordSent = requestPacket.Words[1];
                    if (string.Equals(hashedSaltedPassword, passwordSent, StringComparison.InvariantCultureIgnoreCase))
                    {
                        responsePacket.Words.Add("OK");
                    }
                    else
                    {
                        responsePacket.Words.Add("InvalidPasswordHash");
                    }

                    return true;
                }

                #endregion
            }
            return false;
        }

        #endregion
    }
}