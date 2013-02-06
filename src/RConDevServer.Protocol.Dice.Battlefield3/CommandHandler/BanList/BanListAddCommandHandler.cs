namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.BanList
{
    using System;
    using System.Linq;
    using Command;
    using Common;
    using Data;

    public class BanListAddCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return CommandNames.BanListAdd; }
        }

        public override bool OnCreatingResponse(PacketSession session, ICommand command, Packet requestPacket, Packet responsePacket)
        {
            if (this.ValidateRequestPacket(requestPacket))
            {
                IdTypes idTypes = session.Server.IdTypes;
                var banTypes = new BanTypes();
                bool itemCreated = false;
                var banListItem = new BanListItem
                    {
                        IdType = idTypes.FirstOrDefault(x => x.Code == requestPacket.Words[1]),
                        IdValue = requestPacket.Words[2],
                        BanType = banTypes.FirstOrDefault(x => x.Code == requestPacket.Words[3]),
                    };
                if (banListItem.BanType.Code == BanTypes.Perm.Code)
                {
                    banListItem.Reason = requestPacket.Words[4];
                    itemCreated = true;
                }
                else if (banListItem.BanType.Code == BanTypes.Seconds.Code)
                {
                    banListItem.Seconds = Convert.ToInt32(requestPacket.Words[4]);
                    banListItem.Reason = requestPacket.Words[5];
                    itemCreated = true;
                }
                else if (banListItem.BanType.Code == BanTypes.Rounds.Code)
                {
                    banListItem.Seconds = Convert.ToInt32(requestPacket.Words[4]);
                    banListItem.Reason = requestPacket.Words[5];
                    itemCreated = true;
                }
                if (itemCreated)
                {
                    session.Server.BanList.Add(banListItem);
                    responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
                }
                else
                {
                    responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
                }
            }
            else
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
            }
            return true;
        }

        private bool ValidateRequestPacket(Packet requestPacket)
        {
            return true;
        }
    }
}