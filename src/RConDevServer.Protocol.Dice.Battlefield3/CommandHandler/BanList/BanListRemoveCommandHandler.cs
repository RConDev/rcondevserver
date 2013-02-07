namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.BanList
{
    using System.Linq;
    using Command;
    using Command.BanList;
    using Common;

    public class BanListRemoveCommandHandler : CommandHandlerBase<BanListRemoveCommand>
    {
        public override string Command
        {
            get { return CommandNames.BanListRemove; }
        }

        public override bool OnCreatingResponse(PacketSession session, BanListRemoveCommand command, Packet requestPacket, Packet responsePacket)
        {
            var idTypes = session.Server.IdTypes;
            if (this.ValidateRequest(requestPacket))
            {
                var idType = idTypes.FirstOrDefault(x => x.Code == requestPacket.Words[1]);
                var idValue = requestPacket.Words[2];

                var banListItem =
                    session.Server.BanList.FirstOrDefault(x => x.IdType.Code == idType.Code && x.IdValue == idValue);
                if (banListItem != null)
                {
                    session.Server.BanList.Remove(banListItem);
                    responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
                }
                else
                {
                    responsePacket.Words.Add(Constants.RESPONSE_NOT_FOUND);
                }
            }
            else
            {
                responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
            }
            return true;
        }

        protected bool ValidateRequest(Packet requestPacket)
        {
            // TODO: Validieren des Requests
            return true;
        }
    }
}