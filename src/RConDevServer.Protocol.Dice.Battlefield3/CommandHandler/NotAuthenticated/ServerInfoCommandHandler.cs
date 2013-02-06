﻿namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.NotAuthenticated
{
    using Command;
    using Common;
    using Interface;

    public class ServerInfoCommandHandler : CommandHandlerBase
    {
        public ServerInfoCommandHandler(IServiceLocator serviceLocator)
        {
            this.ServiceLocator = serviceLocator;
        }

        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return Constants.COMMAND_SERVER_INFO; }
        }

        public override bool OnCreatingResponse(PacketSession session, ICommand command, Packet requestPacket, Packet responsePacket)
        {
            if (requestPacket.Words.Count == 1)
            {
                responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
                foreach (string word in session.Server.ServerInfo.ToWords())
                {
                    responsePacket.Words.Add(word);
                }
            }
            else
            {
                responsePacket.Words.Add("InvalidArguments");
            }
            return true;
        }

        #endregion

        public IServiceLocator ServiceLocator { get; set; }
    }
}