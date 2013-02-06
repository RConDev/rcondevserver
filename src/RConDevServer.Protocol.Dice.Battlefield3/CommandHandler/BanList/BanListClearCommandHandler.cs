﻿namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.BanList
{
    using Command;
    using Common;

    public class BanListClearCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return CommandNames.BanListClear; }
        }

        public override bool OnCreatingResponse(PacketSession session, ICommand command, Packet requestPacket, Packet responsePacket)
        {
            session.Server.BanList.Clear();
            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            return true;
        }
    }
}