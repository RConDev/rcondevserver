namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.NotAuthenticated
{
    using System;
    using Command;
    using Command.NotAuthenticated;
    using Common;
    using Util;

    public class LoginHashedHandler : CommandHandlerBase<LoginHashedCommand>
    {
        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return Constants.COMMAND_LOGIN_HASHED; }
        }

        public override bool OnCreatingResponse(PacketSession session, LoginHashedCommand command, Packet requestPacket, Packet responsePacket)
        {
            if (string.Equals(requestPacket.Words[0], Constants.COMMAND_LOGIN_HASHED,
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