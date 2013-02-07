namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.BanList
{
    using System;
    using Command;
    using Command.BanList;
    using Common;
    using Data;
    using Util;

    public class BanListListCommandHandler : CommandHandlerBase<BanListListCommand>
    {
        public override string Command
        {
            get { return CommandNames.BanListList; }
        }

        public override bool OnCreatingResponse(PacketSession session, BanListListCommand command, Packet requestPacket, Packet responsePacket)
        {
            BanList banList = session.Server.BanList;

            if (requestPacket.Words.Count == 2
                && !string.IsNullOrEmpty(requestPacket.Words[1]))
            {
                var index = Convert.ToInt32(requestPacket.Words[1]);
                responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
                StringListExtensions.AddRange(responsePacket.Words, banList.ToWords(index));
                return true;
            }

            responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
            StringListExtensions.AddRange(responsePacket.Words, session.Server.BanList.ToWords(0));
            return true;
        }
    }
}